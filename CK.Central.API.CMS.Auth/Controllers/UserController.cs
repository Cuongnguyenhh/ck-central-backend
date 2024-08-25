using Asp.Versioning;
using CK.Central.Core.Abstract.Services;
using CK.Central.Core.CMS.Auth.Abstract.Repositories;
using CK.Central.Core.CMS.Auth.Abstract.Services;
using CK.Central.Core.Constants;
using CK.Central.Core.Domain.DataObjects.CMS.Model;
using Grpc.Net.Client.Configuration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

namespace CK.Central.API.CMS.Auth.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckcmsauth + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        private readonly IAppSettingService _appSettingService;
        private readonly IJWTokenService _jWTokenService;
        private readonly IIdentityUserRepository _repository;
        private readonly IElasticsearchCMSAuthService _elasticsearchService;
        private readonly IRedisCacheCMSAuthService _redisCacheService;
        private readonly IMemoryCacheCMSAuthService _memoryCacheService;
        private readonly IRabbitMQProducerCMSAuthService _rabbitMQProducerService;

        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly RoleManager<ApplicationRoleModel> _roleManager;

        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly AsyncTimeoutPolicy _timeoutPolicy;
        private readonly AsyncFallbackPolicy _fallbackPolicy;
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly AsyncBulkheadPolicy _bulkheadPolicy;
        private readonly AsyncRateLimitPolicy _ratelimitPolicy;
        private readonly HedgingPolicy _hedgingPolicy;

        public UserController(ILogger<UserController> logger,
            IMediator mediator,
            IAppSettingService appSettingService,
            IJWTokenService jWTokenService,
            IIdentityUserRepository repository,
            IElasticsearchCMSAuthService elasticsearchService,
            IRedisCacheCMSAuthService redisCacheService,
            IMemoryCacheCMSAuthService memoryCacheService,
            IRabbitMQProducerCMSAuthService rabbitMQProducerService,
            UserManager<ApplicationUserModel> userManager,
            RoleManager<ApplicationRoleModel> roleManager)
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
            _userManager = userManager;
            _roleManager = roleManager;
            _retryPolicy = Policy.Handle<OpenApiException>().WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)));
            _timeoutPolicy = Policy.TimeoutAsync(10, TimeoutStrategy.Pessimistic);
            _fallbackPolicy = Policy.Handle<OpenApiException>().FallbackAsync((action) => { return Task.CompletedTask; });
            _circuitBreakerPolicy = Policy.Handle<OpenApiException>().CircuitBreakerAsync(3, TimeSpan.FromMinutes(1));
            _bulkheadPolicy = Policy.BulkheadAsync(3, 6);
            _ratelimitPolicy = Policy.RateLimitAsync(3, TimeSpan.FromSeconds(1));
            _hedgingPolicy = new HedgingPolicy();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApplicationUserModel>> GetUserProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var role = await _userManager.GetRolesAsync(user);
                var roles = new List<ApplicationRoleModel>();

                return Ok(new ApplicationUserModel
                {
                    UserName = user.UserName,
                    FisrtName = user.FisrtName,
                    LastName = user.LastName,
                    FullName = user.FullName,
                    Email = user.Email
                });
            }

            return BadRequest(HttpStatusCode.BadRequest);
        }


        [HttpGet("[action]")]
        public async Task<ActionResult<List<ApplicationUserModel>>> GetAllUserAsync()
        {
            var users = await _repository.GetAll();

            List<ApplicationUserModel> applicationUsers = users
            .Select(t => new ApplicationUserModel
            {
                Id = t.Id,
                FisrtName = t.FisrtName,
                LastName = t.LastName,
                FullName = t.LastName,
                Email = t.Email,
                IsAdmin = t.IsAdmin
            }).ToList();

            return applicationUsers;
        }
    }
}
