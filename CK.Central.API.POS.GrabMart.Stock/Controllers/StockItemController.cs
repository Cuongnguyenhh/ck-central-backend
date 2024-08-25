using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.DataObjects.POS.Entity;
using CK.Central.Core.Domain.DataObjects.POS.Response;
using CK.Central.Core.POS.GrabMart.Stock.Abstract.Repositories;
using CK.Central.Core.POS.GrabMart.Stock.Abstract.Services;
using CK.Central.Core.POS.GrabMart.Stock.Commands;
using CK.Central.Core.POS.GrabMart.Stock.Services;
using Grpc.Net.Client.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retry;
using Polly.Timeout;
using Newtonsoft.Json;

namespace CK.Central.API.POS.GrabMart.Stock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockItemController : ControllerEntityBase<StockItemEntity>
    {
        private readonly IMediator _mediator;
        private readonly IStockItemRepository _repository;
        private readonly ILogger<StockItemController> _logger;
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

        public StockItemController(ILogger<StockItemController> logger, 
            IMediator mediator,
            IStockItemRepository repository,
            IElasticsearchPOSGrabMartStockService elasticsearchService,
            IRedisCachePOSGrabMartStockService redisCacheService,
            IKafkaProducerPOSGrabMartStockService kafkaProducerService,
            AsyncRetryPolicy retryPolicy, AsyncTimeoutPolicy timeoutPolicy,
            AsyncFallbackPolicy fallbackPolicy, AsyncCircuitBreakerPolicy circuitBreakerPolicy,
            AsyncBulkheadPolicy bulkheadPolicy, AsyncRateLimitPolicy ratelimitPolicy, HedgingPolicy hedgingPolicy
            ) : base(repository)
        {
            _logger = logger;
            _mediator = mediator;
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

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CheckStockResponseDto>> CheckStock([FromBody] CheckStockCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation(JsonConvert.SerializeObject(result));
                await _kafkaProducerService.ProduceEvent(Core.Domain.GrabMart.Constants.KafkaTopicReceive.request_check_stock_item, JsonConvert.SerializeObject(result));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
