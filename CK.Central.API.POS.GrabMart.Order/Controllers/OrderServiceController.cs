using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.DataObjects.POS.Entity;
using CK.Central.Core.POS.GrabMart.Order.Abstract.Repositories;
using CK.Central.Core.POS.GrabMart.Order.Abstract.Services;
using CK.Central.Core.POS.GrabMart.Order.Services;
using Grpc.Net.Client.Configuration;
using Microsoft.AspNetCore.Mvc;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retry;
using Polly.Timeout;

namespace CK.Central.API.POS.GrabMart.Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderServiceController : ControllerEntityBase<OrderServiceEntity>
    {
        private readonly IOrderServiceRepository _repository;
        private readonly ILogger<OrderServiceController> _logger;
        private readonly IElasticsearchPOSGrabMartOrderService _elasticsearchService;
        private readonly IRedisCachePOSGrabMartOrderService _redisCacheService;
        private readonly IKafkaProducerPOSGrabMartOrderService _kafkaProducerService;

        private AsyncRetryPolicy _retryPolicy;
        private AsyncTimeoutPolicy _timeoutPolicy;
        private AsyncFallbackPolicy _fallbackPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private AsyncBulkheadPolicy _bulkheadPolicy;
        private AsyncRateLimitPolicy _ratelimitPolicy;
        private HedgingPolicy _hedgingPolicy;

        public OrderServiceController(ILogger<OrderServiceController> logger, IOrderServiceRepository repository,
            IElasticsearchPOSGrabMartOrderService elasticsearchService,
            IRedisCachePOSGrabMartOrderService redisCacheService,
            IKafkaProducerPOSGrabMartOrderService kafkaProducerService,
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
