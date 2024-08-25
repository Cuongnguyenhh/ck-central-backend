using Asp.Versioning;
using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.GrabMart.Store.Abstract.Repositories;
using CK.Central.Core.GrabMart.Store.Abstract.Services;
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

namespace CK.Central.API.GrabMart.Store.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class StoreHistoricalController : ControllerEntityBase<StoreHistoricalEntity>
    {
        private readonly IStoreHistoricalRepository _repository;
        private readonly ILogger<StoreHistoricalController> _logger;
        private readonly IElasticsearchGrabMartStoreService _elasticsearchService;
        private readonly IRedisCacheGrabMartStoreService _redisCacheService;
        private readonly IKafkaProducerGrabMartStoreService _kafkaProducerService;

        private AsyncRetryPolicy _retryPolicy;
        private AsyncTimeoutPolicy _timeoutPolicy;
        private AsyncFallbackPolicy _fallbackPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private AsyncBulkheadPolicy _bulkheadPolicy;
        private AsyncRateLimitPolicy _ratelimitPolicy;
        private HedgingPolicy _hedgingPolicy;

        public StoreHistoricalController(ILogger<StoreHistoricalController> logger, 
            IStoreHistoricalRepository repository,
            IElasticsearchGrabMartStoreService elasticsearchService,
            IRedisCacheGrabMartStoreService redisCacheService,
            IKafkaProducerGrabMartStoreService kafkaProducerService
            ) : base(repository)
        {
            _logger = logger;
            _repository = repository;
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
