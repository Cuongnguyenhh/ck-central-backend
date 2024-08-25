using Asp.Versioning;
using CK.Central.Core.Abstract.Services;
using CK.Central.Core.Constants;
using CK.Central.Core.GrabMart.Abstract.Services;
using Grpc.Net.Client.Configuration;
using Microsoft.AspNetCore.Authorization;
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

namespace CK.Central.API.GrabMart.Job.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckgrabmartjob + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class HomeController : Controller
    {
        private readonly IAppSettingService _appSettingService;
        private readonly ILogger<HomeController> _logger;
        private readonly IElasticsearchGrabMartService _elasticsearchService;
        private readonly IRedisCacheGrabMartService _redisCacheService;
        private readonly IKafkaProducerGrabMartService _kafkaProducerService;
        private readonly IJWTokenService _jWTokenService;

        private AsyncRetryPolicy _retryPolicy;
        private AsyncTimeoutPolicy _timeoutPolicy;
        private AsyncFallbackPolicy _fallbackPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private AsyncBulkheadPolicy _bulkheadPolicy;
        private AsyncRateLimitPolicy _ratelimitPolicy;
        private HedgingPolicy _hedgingPolicy;

        public HomeController(ILogger<HomeController> logger,
            IAppSettingService appSettingService,
            IJWTokenService jWTokenService,
            IElasticsearchGrabMartService elasticsearchService,
            IRedisCacheGrabMartService redisCacheService,
            IKafkaProducerGrabMartService kafkaProducerService
            )
        {
            _logger = logger;
            _appSettingService = appSettingService;
            _jWTokenService = jWTokenService;
            _elasticsearchService = elasticsearchService;
            _redisCacheService = redisCacheService;
            _kafkaProducerService = kafkaProducerService;
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
