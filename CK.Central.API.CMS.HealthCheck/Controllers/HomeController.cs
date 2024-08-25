using Asp.Versioning;
using CK.Central.Core.Abstract.Services;
using CK.Central.Core.CMS.HealthCheck.Abstract.Services;
using Grpc.Net.Client.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.HealthChecks;
using Microsoft.OpenApi.Exceptions;
using System.Diagnostics;
using Polly;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retry;
using Polly.Timeout;
using CK.Central.Core.Constants;

namespace CK.Central.API.CMS.HealthCheck.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckcmshealthcheck + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class HomeController : Controller
    {
        private readonly IHealthCheckService _healthCheck;
        private readonly ILogger<HomeController> _logger;
        private readonly IAppSettingService _appSettingService;
        private readonly IJWTokenService _jWTokenService;
        private readonly IElasticsearchCMSHealthCheckService _elasticsearchService;
        private readonly IRedisCacheCMSHealthCheckService _redisCacheService;
        private readonly IMemoryCacheCMSHealthCheckService _memoryCacheService;
        private readonly IRabbitMQProducerCMSHealthCheckService _rabbitMQProducerService;

        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly AsyncTimeoutPolicy _timeoutPolicy;
        private readonly AsyncFallbackPolicy _fallbackPolicy;
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly AsyncBulkheadPolicy _bulkheadPolicy;
        private readonly AsyncRateLimitPolicy _ratelimitPolicy;
        private readonly HedgingPolicy _hedgingPolicy;

        public HomeController(IHealthCheckService healthCheck,
            ILogger<HomeController> logger,
            IAppSettingService appSettingService,
            IJWTokenService jWTokenService,
            IElasticsearchCMSHealthCheckService elasticsearchService,
            IRedisCacheCMSHealthCheckService redisCacheService,
            IMemoryCacheCMSHealthCheckService memoryCacheService,
            IRabbitMQProducerCMSHealthCheckService rabbitMQProducerService)
        {
            _healthCheck = healthCheck;
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

        //public async Task<IActionResult> Index()
        //{
        //    var timedTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        //    var stopwatch = Stopwatch.StartNew();
        //    var checkResult = await _healthCheck.CheckHealthAsync(timedTokenSource.Token);
        //    ViewBag.ExecutionTime = stopwatch.Elapsed;
        //    return View(checkResult);
        //}
    }
}
