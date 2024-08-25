using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.DataObjects.POS.Entity;
using CK.Central.Core.POS.GrabMart.Stock.Abstract.Repositories;
using CK.Central.Core.POS.GrabMart.Stock.Abstract.Services;
using CK.Central.Core.POS.GrabMart.Stock.Services;
using Grpc.Net.Client.Configuration;
using Microsoft.AspNetCore.Mvc;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retry;
using Polly.Timeout;

namespace CK.Central.API.POS.GrabMart.Stock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockServiceController : ControllerEntityBase<StockServiceEntity>
    {
        private readonly IStockServiceRepository _repository;
        private readonly ILogger<StockServiceController> _logger;
        private readonly IElasticsearchPOSGrabMartStockService _elasticsearchService;
        private readonly IRedisCachePOSGrabMartStockService _redisCacheService;
        private readonly IKafkaProducerPOSGrabMartStockService _kafkaProducerService;

        private AsyncRetryPolicy _retryPolicy;
        private AsyncTimeoutPolicy _timeoutPolicy;
        private AsyncFallbackPolicy _fallbackPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private AsyncBulkheadPolicy _bulkheadPolicy;
        private AsyncRateLimitPolicy _ratelimitPolicy;
        private HedgingPolicy _hedgingPolicy;

        public StockServiceController(ILogger<StockServiceController> logger, IStockServiceRepository repository,
            IElasticsearchPOSGrabMartStockService elasticsearchService,
            IRedisCachePOSGrabMartStockService redisCacheService,
            IKafkaProducerPOSGrabMartStockService kafkaProducerService,
            AsyncRetryPolicy retryPolicy, AsyncTimeoutPolicy timeoutPolicy,
            AsyncFallbackPolicy fallbackPolicy, AsyncCircuitBreakerPolicy circuitBreakerPolicy,
            AsyncBulkheadPolicy bulkheadPolicy, AsyncRateLimitPolicy ratelimitPolicy, HedgingPolicy hedgingPolicy
            ) : base(repository)
        {
            _logger = logger;
            _repository = repository;
            _elasticsearchService = elasticsearchService;
            _redisCacheService = redisCacheService;
            _kafkaProducerService = kafkaProducerService;
            _retryPolicy = retryPolicy;
            _timeoutPolicy = timeoutPolicy;
            _fallbackPolicy = fallbackPolicy;
            _circuitBreakerPolicy = circuitBreakerPolicy;
            _bulkheadPolicy = bulkheadPolicy;
            _ratelimitPolicy = ratelimitPolicy;
            _hedgingPolicy = hedgingPolicy;
        }
    }
}
