using CK.Central.Core.CMS.Portal.Abstract.Repositories;
using CK.Central.Core.CMS.Portal.Abstract.Services;
using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.CMS.Constants;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
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
using CK.Central.Core.Constants;
using Asp.Versioning;

namespace CK.Central.API.CMS.Portal.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckcmsportal + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class ReportController : ControllerEntityBase<ReportEntity>
    {
        private readonly IReportRepository _repository;
        private readonly ILogger<ReportController> _logger;
        private readonly IElasticsearchCMSPortalService _elasticsearchService;
        private readonly IMemoryCacheCMSPortalService _memoryCacheService;
        private readonly IRedisCacheCMSPortalService _redisCacheService;
        private readonly IRabbitMQProducerCMSPortalService _rabbitMQProducerService;

        private AsyncRetryPolicy _retryPolicy;
        private AsyncTimeoutPolicy _timeoutPolicy;
        private AsyncFallbackPolicy _fallbackPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private AsyncBulkheadPolicy _bulkheadPolicy;
        private AsyncRateLimitPolicy _ratelimitPolicy;
        private HedgingPolicy _hedgingPolicy;

        public ReportController(ILogger<ReportController> logger, IReportRepository repository,
            IElasticsearchCMSPortalService elasticsearchService,
            IMemoryCacheCMSPortalService memoryCacheService,
            IRedisCacheCMSPortalService redisCacheService,
            IRabbitMQProducerCMSPortalService rabbitMQProducerService
            ) : base(repository)
        {
            _logger = logger;
            _repository = repository;
            _elasticsearchService = elasticsearchService;
            _memoryCacheService = memoryCacheService;
            _redisCacheService = redisCacheService;
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