using Asp.Versioning;
using CK.Central.Core.Constants;
using CK.Central.Core.Controllers;
using CK.Central.Core.POS.HealthCheck.Abstract.Repositories;
using CK.Central.Core.POS.HealthCheck.Abstract.Services;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
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
using CK.Central.Core.POS.HealthCheck.Services;

namespace CK.Central.API.POS.HealthCheck.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckposhealthcheck + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class HealthcheckActivityController : ControllerEntityBase<HealthcheckActivityEntity>
    {
        private readonly IHealthcheckActivityRepository _repository;
        private readonly ILogger<HealthcheckActivityController> _logger;
        private readonly IElasticsearchPOSHealthCheckService _elasticsearchService;
        private readonly IRedisCachePOSHealthCheckService _redisCacheService;

        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly AsyncTimeoutPolicy _timeoutPolicy;
        private readonly AsyncFallbackPolicy _fallbackPolicy;
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly AsyncBulkheadPolicy _bulkheadPolicy;
        private readonly AsyncRateLimitPolicy _ratelimitPolicy;
        private readonly HedgingPolicy _hedgingPolicy;

        public HealthcheckActivityController(ILogger<HealthcheckActivityController> logger,
            IHealthcheckActivityRepository repository,
            IElasticsearchPOSHealthCheckService elasticsearchService,
            IRedisCachePOSHealthCheckService redisCacheService) : base(repository)
        {
            _logger = logger;
            _repository = repository;
            _elasticsearchService = elasticsearchService;
            _redisCacheService = redisCacheService;
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
