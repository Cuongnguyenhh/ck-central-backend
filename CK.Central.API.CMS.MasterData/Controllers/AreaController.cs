using Asp.Versioning;
using CK.Central.Core.CMS.MasterData.Abstract.Repositories;
using CK.Central.Core.CMS.MasterData.Abstract.Services;
using CK.Central.Core.Constants;
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

namespace CK.Central.API.CMS.MasterData.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckcmsmasterdata + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class AreaController : ControllerEntityBase<AreaEntity>
    {
        private readonly IAreaRepository _repository;
        private readonly ILogger<AreaController> _logger;
        private readonly IElasticsearchCMSMasterDataService _elasticsearchService;
        private readonly IMemoryCacheCMSMasterDataService _memoryCacheService;
        private readonly IRedisCacheCMSMasterDataService _redisCacheService;
        private readonly IRabbitMQProducerCMSMasterDataService _rabbitMQProducerService;

        private AsyncRetryPolicy _retryPolicy;
        private AsyncTimeoutPolicy _timeoutPolicy;
        private AsyncFallbackPolicy _fallbackPolicy;
        private AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private AsyncBulkheadPolicy _bulkheadPolicy;
        private AsyncRateLimitPolicy _ratelimitPolicy;
        private HedgingPolicy _hedgingPolicy;

        public AreaController(ILogger<AreaController> logger, IAreaRepository repository,
            IElasticsearchCMSMasterDataService elasticsearchService,
            IMemoryCacheCMSMasterDataService memoryCacheService,
            IRedisCacheCMSMasterDataService redisCacheService,
            IRabbitMQProducerCMSMasterDataService rabbitMQProducerService
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
        public async Task<IActionResult> GetAllActiveAsync()
        {
            try
            {
                var cacheData = await _retryPolicy.ExecuteAsync<IEnumerable<AreaEntity>>(
                    async () => await _redisCacheService.GetData<IEnumerable<AreaEntity>>(RedisCachingKey.AreaListActive));

                if (cacheData != null) return Ok(cacheData);

                Expression<Func<AreaEntity, bool>> query = x => x.IsActive == true && x.IsDeleted == false;

                cacheData = await _retryPolicy.ExecuteAsync<IEnumerable<AreaEntity>>(
                    async () => await _repository.Filter(query));

                if (cacheData == null) return Ok(null);

                await _retryPolicy.ExecuteAsync<bool>(
                    async () => await _redisCacheService.SetData<IEnumerable<AreaEntity>>(RedisCachingKey.AreaListActive, cacheData));

                return Ok(cacheData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
