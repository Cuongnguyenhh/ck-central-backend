using Asp.Versioning;
using CK.Central.Core.Abstract.Services;
using CK.Central.Core.CMS.Abstract.Services;
using CK.Central.Core.CMS.Generate.Abstract.Services;
using CK.Central.Core.Constants;
using CK.Central.Core.Domain.DataObjects.CMS.Model;
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

namespace CK.Central.API.CMS.Generate.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckcmsgenerate + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppSettingService _appSettingService;
        private readonly IJWTokenService _jWTokenService;
        private readonly IElasticsearchCMSGenerateService _elasticsearchService;
        private readonly IRedisCacheCMSGenerateService _redisCacheService;
        private readonly IMemoryCacheCMSGenerateService _memoryCacheService;
        private readonly IRabbitMQProducerCMSGenerateService _rabbitMQProducerService;

        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly AsyncTimeoutPolicy _timeoutPolicy;
        private readonly AsyncFallbackPolicy _fallbackPolicy;
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly AsyncBulkheadPolicy _bulkheadPolicy;
        private readonly AsyncRateLimitPolicy _ratelimitPolicy;
        private readonly HedgingPolicy _hedgingPolicy;

        public HomeController(ILogger<HomeController> logger,
            IAppSettingService appSettingService,
            IJWTokenService jWTokenService,
            IElasticsearchCMSGenerateService elasticsearchService,
            IRedisCacheCMSGenerateService redisCacheService,
            IMemoryCacheCMSGenerateService memoryCacheService,
            IRabbitMQProducerCMSGenerateService rabbitMQProducerService)
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
        }
    }
}
