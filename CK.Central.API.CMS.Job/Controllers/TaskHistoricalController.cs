using Asp.Versioning;
using CK.Central.Core.Constants;
using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using CK.Central.Core.CMS.Job.Abstract.Services;
using CK.Central.Core.CMS.Job.Abstract.Repositories;
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

namespace CK.Central.API.CMS.Job.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckcmsjob + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class TaskHistoricalController : ControllerEntityBase<TaskHistoricalEntity>
    {
        private readonly ITaskHistoricalRepository _repository;
        private readonly ILogger<TaskHistoricalController> _logger;
        private readonly IElasticsearchCMSJobService _elasticsearchService;
        private readonly IRedisCacheCMSJobService _redisCacheService;
        private readonly IMemoryCacheCMSJobService _memoryCacheService;
        private readonly IRabbitMQProducerCMSJobService _rabbitMQProducerService;

        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly AsyncTimeoutPolicy _timeoutPolicy;
        private readonly AsyncFallbackPolicy _fallbackPolicy;
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly AsyncBulkheadPolicy _bulkheadPolicy;
        private readonly AsyncRateLimitPolicy _ratelimitPolicy;
        private readonly HedgingPolicy _hedgingPolicy;

        public TaskHistoricalController(ILogger<TaskHistoricalController> logger,
            ITaskHistoricalRepository repository,
            IElasticsearchCMSJobService elasticsearchService,
            IRedisCacheCMSJobService redisCacheService,
            IMemoryCacheCMSJobService memoryCacheService,
            IRabbitMQProducerCMSJobService rabbitMQProducerService) : base(repository)
        {
            _logger = logger;
            _repository = repository;
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
