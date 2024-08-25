using Asp.Versioning;
using CK.Central.Core.Abstract.Services;
using CK.Central.Core.CMS.Abstract.Services;
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
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.OpenApi.Exceptions;
using Polly;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retry;
using Polly.Timeout;

namespace CK.Central.API.CMS.Auth.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    //[Route("{ApiSubdomainRoute.ckcmsauth}/api/v{version:apiVersion}/[controller]")]
    [Route(ApiSubdomainRoute.ckcmsauth + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class TokenController : Controller
    {
        private readonly ILogger<TokenController> _logger;
        private readonly IAppSettingService _appSettingService;
        private readonly IJWTokenService _jWTokenService;
        private readonly IElasticsearchCMSService _elasticsearchService;
        private readonly IRedisCacheCMSService _redisCacheService;
        private readonly IMemoryCacheCMSService _memoryCacheService;
        private readonly IRabbitMQProducerCMSService _rabbitMQProducerService;

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

        public TokenController(ILogger<TokenController> logger,
            IAppSettingService appSettingService,
            IJWTokenService jWTokenService,
            IElasticsearchCMSService elasticsearchService,
            IRedisCacheCMSService redisCacheService,
            IMemoryCacheCMSService memoryCacheService,
            IRabbitMQProducerCMSService rabbitMQProducerService,
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
    }
}
