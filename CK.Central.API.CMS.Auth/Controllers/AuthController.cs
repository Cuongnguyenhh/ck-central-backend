using Asp.Versioning;
using CK.Central.Core.Abstract.Services;
using CK.Central.Core.CMS.Auth.Abstract.Services;
using CK.Central.Core.Constants;
using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.Constants.CMS;
using CK.Central.Core.Domain.DataObjects.CMS.Model;
using CK.Central.Core.Domain.DataObjects.CMS.Request;
using CK.Central.Core.Domain.DataObjects.CMS.Response;
using Grpc.Net.Client.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.OpenApi.Exceptions;
using Polly;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retry;
using Polly.Timeout;
using System.Net;
using System.Web;

namespace CK.Central.API.CMS.Auth.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckcmsauth + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAppSettingService _appSettingService;
        private readonly IJWTokenService _jWTokenService;
        private readonly IElasticsearchCMSAuthService _elasticsearchService;
        private readonly IRedisCacheCMSAuthService _redisCacheService;
        private readonly IMemoryCacheCMSAuthService _memoryCacheService;
        private readonly IRabbitMQProducerCMSAuthService _rabbitMQProducerService;

        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly RoleManager<ApplicationRoleModel> _roleManager;
        private readonly SignInManager<ApplicationUserModel> _signInManager;

        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly AsyncTimeoutPolicy _timeoutPolicy;
        private readonly AsyncFallbackPolicy _fallbackPolicy;
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly AsyncBulkheadPolicy _bulkheadPolicy;
        private readonly AsyncRateLimitPolicy _ratelimitPolicy;
        private readonly HedgingPolicy _hedgingPolicy;

        public AuthController(ILogger<AuthController> logger,
            IAppSettingService appSettingService,
            IJWTokenService jWTokenService,
            IElasticsearchCMSAuthService elasticsearchService,
            IRedisCacheCMSAuthService redisCacheService,
            IMemoryCacheCMSAuthService memoryCacheService,
            IRabbitMQProducerCMSAuthService rabbitMQProducerService,
            UserManager<ApplicationUserModel> userManager,
            RoleManager<ApplicationRoleModel> roleManager,
            SignInManager<ApplicationUserModel> signInManager)
        {
            _logger = logger;
            _appSettingService = appSettingService;
            _jWTokenService = jWTokenService;
            _elasticsearchService = elasticsearchService;
            _redisCacheService = redisCacheService;
            _memoryCacheService = memoryCacheService;
            _rabbitMQProducerService = rabbitMQProducerService;
            _retryPolicy = Policy.Handle<OpenApiException>().WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)));
            _timeoutPolicy = Policy.TimeoutAsync(10, TimeoutStrategy.Pessimistic);
            _fallbackPolicy = Policy.Handle<OpenApiException>().FallbackAsync((action) => { return Task.CompletedTask; });
            _circuitBreakerPolicy = Policy.Handle<OpenApiException>().CircuitBreakerAsync(3, TimeSpan.FromMinutes(1));
            _bulkheadPolicy = Policy.BulkheadAsync(3, 6);
            _ratelimitPolicy = Policy.RateLimitAsync(3, TimeSpan.FromSeconds(1));
            _hedgingPolicy = new HedgingPolicy();
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticateResponseDto>> Authenticate([FromBody] AuthenticateRequestDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var managerUser = await _userManager.FindByNameAsync(model.Username);

                if (managerUser == null) return BadRequest(ModelState);

                if(managerUser.IsActive == false || managerUser.IsDeleted == true) return BadRequest(ModelState);

                var isPasswordValid = await _userManager.CheckPasswordAsync(managerUser, model.Password!);

                if (!isPasswordValid) return BadRequest(ModelState);

                var roles = await _userManager.GetRolesAsync(managerUser);

                if(roles == null) return BadRequest(ModelState);

                if(roles.Count == 0) return BadRequest(ModelState);

                var jwt = await _jWTokenService.CreateAccessToken(new AccessTokenRequestDto
                {
                    Email = managerUser.Email,
                    Password = model.Password,
                    Username = model.Username,
                    Roles = new List<string>(roles)
                });

                if (jwt is null) return BadRequest(ModelState);

                var token = await _jWTokenService.CreateAccessToken(jwt);

                var reponse = new AuthenticateResponseDto
                {
                    UserId = managerUser.Id,
                    UserName = model.Username,
                    Email = managerUser.Email,
                    AccessToken = token.AccessToken,
                    RefreshToken = token.RefreshToken,
                    AccessTokenExpiryTime = token.AccessTokenExpiryTime,
                    RefreshTokenExpiryTime = token.RefreshTokenExpiryTime,
                    Roles = new List<string>(roles),
                    Message = StatusCodes.Status202Accepted.ToString()
                };

                return Ok(reponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequestDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                if (await _userManager.FindByEmailAsync(model.Email) is not null)
                    return BadRequest(ModelState);

                if (await _userManager.FindByNameAsync(model.Username) is not null)
                    return BadRequest(ModelState);

                var user = new ApplicationUserModel()
                {
                    UserName = model.Username,
                    FullName = model.Username,
                    Email = model.Email,
                    FisrtName = model.FirstName,
                    LastName = model.LastName,
                    EmployeeCode = model.EmployeeCode,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = model.ActionBy,
                    CreatedDatetime = DateTime.Now,
                    IsAdmin = (model.Role.Trim() == StaticUserRoles.AdminIt || model.Role.Trim() == StaticUserRoles.AdminBd ? true : false)
                };

                var userResult = await _userManager.CreateAsync(user, model.Password);

                if (!userResult.Succeeded) return BadRequest(userResult);

                var roleResult = await _userManager.AddToRoleAsync(user, model.Role);

                if (!roleResult.Succeeded) return BadRequest(roleResult);

                return Ok(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok(HttpStatusCode.OK);
        }

        [Authorize]
        [HttpPost("reset-password")]
        public async Task<ResetPasswordResponseDto<string>> ResetPassword([FromBody] ResetPasswordRequestDto model)
        {
            ResetPasswordResponseDto<string> result = new ResetPasswordResponseDto<string>();

            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user != null)
            {
                IdentityOptions options = new IdentityOptions();
                var proivder = options.Tokens.EmailConfirmationTokenProvider;
                bool isValid = await _userManager.VerifyUserTokenAsync(user, proivder, "ResetPassword", HttpUtility.UrlDecode(model.Code));

                if (isValid)
                {
                    var resetPassword = await _userManager.ResetPasswordAsync(user, HttpUtility.UrlDecode(model.Code), model.Password);

                    if (resetPassword.Succeeded)
                    {
                        result.Success = true;
                        result.Message = "Your password has been updated successfully.";
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "There is some problem. We are not able to reset your password, Please contact to administrator.";
                    }
                }
                else
                {
                    result.Success = false;
                    result.Message = "Your password reset link has been expied, Please generate different link and try again.";
                }
            }
            else
            {
                result.Success = false;
                result.Message = "Your password reset link has been  expied, Please generate different link and try again.";
            }

            return result;
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<ChangePasswordResponseDto<string>> ChangePassword([FromBody] ChangePasswordRequestDto model)
        {
            ChangePasswordResponseDto<string> result = new ChangePasswordResponseDto<string>();

            var user = await _userManager.FindByIdAsync(model.UserId);
            var passwordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);

            if (passwordResult.Succeeded)
            {
                result.Success = true;
                result.Message = "Password has been updated successfully.";
            }
            else
            {
                string error = passwordResult.Errors.FirstOrDefault().Code;

                if (error == "PasswordMismatch")
                {
                    result.Message = "Current password is incorrect. Please try again";
                }
                else
                {
                    result.Message = "There is some problem. We are not able to change your password. Please contact to administrator.";
                }
                result.Success = false;
            }

            return result;
        }

        [Authorize]
        [HttpGet("forgot-password")]
        public async Task<SendPasswordEmailResponseDto<string>> ForgotPassword([FromBody] SendPasswordEmailRequestDto model)
        {
            SendPasswordEmailResponseDto<string> result = new SendPasswordEmailResponseDto<string>();

            var user = await _userManager.FindByNameAsync(model.Email)
;
            if (user == null)
            {
                result.Message = "We are not able to find your email in the system, Please try again.";
                result.Success = false;
                return result;
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            //ApplicationSettings appSettings = new ApplicationSettings();
            //var url = appSettings.GetConfigurationValue("ApplicationURL", "PasswordResetURL");

            //var callbackUrl = url + "?userId=" + user.Id + "&code=" + HttpUtility.UrlEncode(code);
            //await _emailService.SendEmail(email, user.FirstName, user.LastName, HtmlEncoder.Default.Encode(callbackUrl), "Code Cerculation Password reset link", "ForgotPassword");
            //result.Success = true;

            return result;
        }

        [Authorize]
        [HttpGet("is-authorized")]
        public async Task<IActionResult> IsAuthorized()
        {
            await Task.WhenAll();
            return Ok(StatusCodes.Status200OK);
        }

        [HttpGet("is-route-authorized")]
        public async Task<IActionResult> IsRouteAuthorized()
        {
            await Task.WhenAll();
            return Ok(StatusCodes.Status200OK);
        }
    }
}
