using Asp.Versioning;
using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.GrabMart.Order.Abstract.Repositories;
using CK.Central.Core.GrabMart.Order.Abstract.Services;
using CK.Central.Core.GrabMart.Order.Commands;
using Grpc.Net.Client.Configuration;
using MediatR;
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

namespace CK.Central.API.GrabMart.Order.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class OrderActivityController : ControllerEntityBase<OrderActivityEntity>
    {
        private readonly IMediator _mediator;
        private readonly IOrderActivityRepository _repository;
        private readonly ILogger<OrderActivityController> _logger;
        private readonly IElasticsearchGrabMartOrderService _elasticsearchService;
        private readonly IRedisCacheGrabMartOrderService _redisCacheService;
        private readonly IKafkaProducerGrabMartOrderService _kafkaProducerService;

        private AsyncRetryPolicy _retryPolicy;
        private AsyncTimeoutPolicy _timeoutPolicy;
        private AsyncFallbackPolicy _fallbackPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private AsyncBulkheadPolicy _bulkheadPolicy;
        private AsyncRateLimitPolicy _ratelimitPolicy;
        private HedgingPolicy _hedgingPolicy;

        public OrderActivityController(IMediator mediator,
            ILogger<OrderActivityController> logger, 
            IOrderActivityRepository repository,
            IElasticsearchGrabMartOrderService elasticsearchService,
            IRedisCacheGrabMartOrderService redisCacheService,
            IKafkaProducerGrabMartOrderService kafkaProducerService
            ) : base(repository)
        {
            _logger = logger;
            _mediator = mediator;
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

        [HttpPost("[action]")]
        public async Task<ActionResult<CancelOrderResponseDto>> CancelOrderAsync([FromBody] CancelOrderCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (!ModelState.IsValid) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<EditOrderResponseDto>> EditOrderAsync([FromBody] EditOrdersCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (!ModelState.IsValid) return BadRequest(result);

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
