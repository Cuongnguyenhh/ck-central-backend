using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.GrabMart.Campaign.Abstract.Repositories;
using CK.Central.Core.GrabMart.Campaign.Abstract.Services;
using Grpc.Net.Client.Configuration;
using Microsoft.AspNetCore.Mvc;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retry;
using Polly.Timeout;

namespace CK.Central.API.GrabMart.Campaign.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignHistoricalController : ControllerEntityBase<CampaignHistoricalEntity>
    {
        private readonly ICampaignHistoricalRepository _repository;
        private readonly ILogger<CampaignHistoricalController> _logger;
        private readonly IElasticsearchGrabMartCampaignService _elasticsearchService;
        private readonly IRedisCacheGrabMartCampaignService _redisCacheService;
        private readonly IKafkaProducerGrabMartCampaignService _kafkaProducerService;

        private AsyncRetryPolicy _retryPolicy;
        private AsyncTimeoutPolicy _timeoutPolicy;
        private AsyncFallbackPolicy _fallbackPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private AsyncBulkheadPolicy _bulkheadPolicy;
        private AsyncRateLimitPolicy _ratelimitPolicy;
        private HedgingPolicy _hedgingPolicy;

        public CampaignHistoricalController(ILogger<CampaignHistoricalController> logger, ICampaignHistoricalRepository repository,
            IElasticsearchGrabMartCampaignService elasticsearchService,
            IRedisCacheGrabMartCampaignService redisCacheService,
            IKafkaProducerGrabMartCampaignService kafkaProducerService,
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
