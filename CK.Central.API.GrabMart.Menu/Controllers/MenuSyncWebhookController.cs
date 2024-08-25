using Asp.Versioning;
using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Menu.Abstract.Repositories;
using CK.Central.Core.GrabMart.Menu.Abstract.Services;
using CK.Central.Core.GrabMart.Menu.Commands;
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

namespace CK.Central.API.GrabMart.Menu.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class MenuSyncWebhookController : ControllerEntityBase<MenuSyncWebhookEntity>
    {
        private readonly IMediator _mediator;
        private readonly IMenuSyncWebhookRepository _repository;
        private readonly ILogger<MenuSyncWebhookController> _logger;
        private readonly IElasticsearchGrabMartMenuService _elasticsearchService;
        private readonly IRedisCacheGrabMartMenuService _redisCacheService;
        private readonly IKafkaProducerGrabMartMenuService _kafkaProducerService;

        private AsyncRetryPolicy _retryPolicy;
        private AsyncTimeoutPolicy _timeoutPolicy;
        private AsyncFallbackPolicy _fallbackPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private AsyncBulkheadPolicy _bulkheadPolicy;
        private AsyncRateLimitPolicy _ratelimitPolicy;
        private HedgingPolicy _hedgingPolicy;

        public MenuSyncWebhookController(IMediator mediator,
            ILogger<MenuSyncWebhookController> logger, 
            IMenuSyncWebhookRepository repository,
            IElasticsearchGrabMartMenuService elasticsearchService,
            IRedisCacheGrabMartMenuService redisCacheService,
            IKafkaProducerGrabMartMenuService kafkaProducerService
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
        public async Task<ActionResult<PartnerMenuSyncWebhookResponseDto>> PartnerMenuNotificationAsync([FromBody] MenuSyncWebhookCommand command)
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
