using Asp.Versioning;
using CK.Central.Core.Abstract.Services;
using CK.Central.Core.CMS.Auth.Abstract.Repositories;
using CK.Central.Core.CMS.Auth.Abstract.Services;
using CK.Central.Core.Constants;
using CK.Central.Core.Domain.Constants.CMS;
using CK.Central.Core.Domain.DataObjects.CMS.Model;
using CK.Central.Core.Domain.DataObjects.CMS.Request;
using CK.Central.Core.Domain.DataObjects.CMS.Response;
using Elastic.Apm.Api;
using Grpc.Net.Client.Configuration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.OpenApi.Exceptions;
using Polly;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retry;
using Polly.Timeout;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CK.Central.API.CMS.Auth.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckcmsauth + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RoleController> _logger;
        private readonly IAppSettingService _appSettingService;
        private readonly IJWTokenService _jWTokenService;
        private readonly IIdentityRoleRepository _repository;
        private readonly IElasticsearchCMSAuthService _elasticsearchService;
        private readonly IRedisCacheCMSAuthService _redisCacheService;
        private readonly IMemoryCacheCMSAuthService _memoryCacheService;
        private readonly IRabbitMQProducerCMSAuthService _rabbitMQProducerService;
        private readonly RoleManager<ApplicationRoleModel> _roleManager;
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly AsyncTimeoutPolicy _timeoutPolicy;
        private readonly AsyncFallbackPolicy _fallbackPolicy;
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly AsyncBulkheadPolicy _bulkheadPolicy;
        private readonly AsyncRateLimitPolicy _ratelimitPolicy;
        private readonly HedgingPolicy _hedgingPolicy;

        public RoleController(ILogger<RoleController> logger,
            IMediator mediator,
            IIdentityRoleRepository repository,
            IAppSettingService appSettingService,
            IJWTokenService jWTokenService,
            IElasticsearchCMSAuthService elasticsearchService,
            IRedisCacheCMSAuthService redisCacheService,
            IMemoryCacheCMSAuthService memoryCacheService,
            IRabbitMQProducerCMSAuthService rabbitMQProducerService,
            RoleManager<ApplicationRoleModel> roleManager,
            UserManager<ApplicationUserModel> userManager)
        {
            _logger = logger;
            _mediator = mediator;
            _repository = repository;
            _appSettingService = appSettingService;
            _jWTokenService = jWTokenService;
            _elasticsearchService = elasticsearchService;
            _redisCacheService = redisCacheService;
            _memoryCacheService = memoryCacheService;
            _rabbitMQProducerService = rabbitMQProducerService;
            _roleManager = roleManager;
            _retryPolicy = Policy.Handle<OpenApiException>().WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)));
            _timeoutPolicy = Policy.TimeoutAsync(10, TimeoutStrategy.Pessimistic);
            _fallbackPolicy = Policy.Handle<OpenApiException>().FallbackAsync((action) => { return Task.CompletedTask; });
            _circuitBreakerPolicy = Policy.Handle<OpenApiException>().CircuitBreakerAsync(3, TimeSpan.FromMinutes(1));
            _bulkheadPolicy = Policy.BulkheadAsync(3, 6);
            _ratelimitPolicy = Policy.RateLimitAsync(3, TimeSpan.FromSeconds(1));
            _hedgingPolicy = new HedgingPolicy();
            _userManager = userManager;
        }

        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles([FromBody] SeedRolesRequestDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                if (model.Roles?.Count == 0) return BadRequest(ModelState);

                foreach (var role in model.Roles)
                    if (await _roleManager.RoleExistsAsync(role))
                        return BadRequest(StatusCodes.Status208AlreadyReported);
                    else
                        await _roleManager.CreateAsync(new ApplicationRoleModel { 
                            Name = role,
                            IsActive = true,
                            IsDeleted = false,
                            CreatedBy = StaticUserRoles.AdminIt,
                            CreatedDatetime = DateTime.UtcNow
                        });

                return Ok(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("get-all-roles")]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpPost]
        [Route("make-admin-it")]
        public async Task<IActionResult> MakeAdminIt([FromBody] UpdatePermissionRequestDto model)
        {
            try
            {
                if (ModelState.IsValid) return BadRequest(ModelState);

                var user = await _userManager.FindByNameAsync(model.Username);

                if (user is null)
                    return BadRequest(ModelState);

                var userRole = await _userManager.AddToRoleAsync(user, StaticUserRoles.AdminIt);

                if (userRole.Succeeded)
                    return Ok(StatusCodes.Status200OK);

                return BadRequest(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("make-admin-bd")]
        public async Task<IActionResult> MakeAdminBd([FromBody] UpdatePermissionRequestDto model)
        {
            try
            {
                if (ModelState.IsValid) return BadRequest(ModelState);

                var user = await _userManager.FindByNameAsync(model.Username);

                if (user is null)
                    return BadRequest(ModelState);

                var userRole = await _userManager.AddToRoleAsync(user, StaticUserRoles.AdminBd);

                if (userRole.Succeeded)
                    return Ok(StatusCodes.Status200OK);

                return BadRequest(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("make-owner")]
        public async Task<IActionResult> MakeOwner([FromBody] UpdatePermissionRequestDto model)
        {
            try
            {
                if (ModelState.IsValid) return BadRequest(ModelState);

                var user = await _userManager.FindByNameAsync(model.Username);

                if (user is null)
                    return BadRequest(ModelState);

                var userRole = await _userManager.AddToRoleAsync(user, StaticUserRoles.Owner);

                if (userRole.Succeeded)
                    return Ok(StatusCodes.Status200OK);

                return BadRequest(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }
    }
}
