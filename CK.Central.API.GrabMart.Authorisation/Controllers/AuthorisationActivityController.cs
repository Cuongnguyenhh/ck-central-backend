using Asp.Versioning;
using CK.Central.Core.Constants;
using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.GrabMart.Authorisation.Abstract.Repositories;
using CK.Central.Core.GrabMart.Authorisation.Abstract.Services;
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

namespace CK.Central.API.GrabMart.Authorisation.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckgrabmartauth + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class AuthorisationActivityController : ControllerEntityBase<AuthorisationActivityEntity>
    {
        private readonly IAuthorisationActivityRepository _repository;
        private readonly ILogger<AuthorisationActivityController> _logger;
        private readonly IElasticsearchGrabMartAuthorisationService _elasticsearchService;
        private readonly IRedisCacheGrabMartAuthorisationService _redisCacheService;
        private readonly IKafkaProducerGrabMartAuthorisationService _kafkaProducerService;

        private AsyncRetryPolicy _retryPolicy;
        private AsyncTimeoutPolicy _timeoutPolicy;
        private AsyncFallbackPolicy _fallbackPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private AsyncBulkheadPolicy _bulkheadPolicy;
        private AsyncRateLimitPolicy _ratelimitPolicy;
        private HedgingPolicy _hedgingPolicy;

        public AuthorisationActivityController(ILogger<AuthorisationActivityController> logger, 
            IAuthorisationActivityRepository repository,
            IElasticsearchGrabMartAuthorisationService elasticsearchService,
            IRedisCacheGrabMartAuthorisationService redisCacheService,
            IKafkaProducerGrabMartAuthorisationService kafkaProducerService
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
