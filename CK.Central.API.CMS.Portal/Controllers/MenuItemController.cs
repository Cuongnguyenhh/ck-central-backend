using CK.Central.Core.CMS.Portal.Abstract.Repositories;
using CK.Central.Core.CMS.Portal.Abstract.Services;
using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.CMS.Constants;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
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
using System.Linq.Expressions;
using CK.Central.Core.Constants;
using Asp.Versioning;
using CK.Central.Core.DataObjects.Dto;

namespace CK.Central.API.CMS.Portal.Controllers
{
    //[Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckcmsportal + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class MenuItemController : ControllerEntityBase<MenuItemEntity>
    {
        private readonly IMenuItemRepository _repository;
        private readonly ILogger<MenuItemController> _logger;
        private readonly IElasticsearchCMSPortalService _elasticsearchService;
        private readonly IMemoryCacheCMSPortalService _memoryCacheService;
        private readonly IRedisCacheCMSPortalService _redisCacheService;
        private readonly IRabbitMQProducerCMSPortalService _rabbitMQProducerService;

        private AsyncRetryPolicy _retryPolicy;
        private AsyncTimeoutPolicy _timeoutPolicy;
        private AsyncFallbackPolicy _fallbackPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private AsyncBulkheadPolicy _bulkheadPolicy;
        private AsyncRateLimitPolicy _ratelimitPolicy;
        private HedgingPolicy _hedgingPolicy;

        public MenuItemController(ILogger<MenuItemController> logger, IMenuItemRepository repository,
            IElasticsearchCMSPortalService elasticsearchService,
            IMemoryCacheCMSPortalService memoryCacheService,
            IRedisCacheCMSPortalService redisCacheService,
            IRabbitMQProducerCMSPortalService rabbitMQProducerService
            ) : base(repository)
        {
            _logger = logger;
            _repository = repository;
            _elasticsearchService = elasticsearchService;
            _memoryCacheService = memoryCacheService;
            _redisCacheService = redisCacheService;
            _rabbitMQProducerService = rabbitMQProducerService;
            _retryPolicy = Policy.Handle<OpenApiException>().WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)));
            _timeoutPolicy = Policy.TimeoutAsync(10, TimeoutStrategy.Pessimistic);
            _fallbackPolicy = Policy.Handle<OpenApiException>().FallbackAsync((action) => { return Task.CompletedTask; });
            _circuitBreakerPolicy = Policy.Handle<OpenApiException>().CircuitBreakerAsync(3, TimeSpan.FromMinutes(1));
            _bulkheadPolicy = Policy.BulkheadAsync(3, 6);
            _ratelimitPolicy = Policy.RateLimitAsync(3, TimeSpan.FromSeconds(1));
            _hedgingPolicy = new HedgingPolicy();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllActiveByMenuIdAsync(Guid menuId)
        {
            try
            {
                Expression<Func<MenuItemEntity, bool>> filter = x => x.MenuUUID == menuId && x.IsActive == true && x.IsDeleted == false;

                return Ok(await _repository.Filter(filter));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertMany")]
        public async Task<IActionResult> InsertMany([FromBody] List<MenuItemEntity> entities)
        {
            if (entities == null || !entities.Any())
            {
                return BadRequest("No entities to insert.");
            }
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = await _repository.InsertMany(entities);
            stopwatch.Stop();

            if (!result)
            {
                return StatusCode(500, "An error occurred while inserting entities.");
            }


            Repos.UOW.Commit();

            var executionTime = stopwatch.ElapsedMilliseconds;
            _logger.LogInformation($"InsertMany executed in {executionTime} ms");

            var response = new
            {
                Message = "Entities inserted successfully.",
                ExecutionTime = $"{executionTime} ms"
            };

            return Ok(BaseResponseDto.Succeed(response));
        }
    }
}