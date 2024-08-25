using System.Linq.Expressions;
using CK.Central.Core.CMS.MasterData.Abstract.Repositories;
using CK.Central.Core.CMS.MasterData.Abstract.Services;
using CK.Central.Core.Domain.CMS.Constants;
using CK.Central.Core.Controllers;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Grpc.Net.Client.Configuration;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retry;
using Polly.Timeout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using CK.Central.Core.Constants;
using Microsoft.OpenApi.Exceptions;
using Asp.Versioning;

namespace CK.Central.API.CMS.MasterData.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckcmsmasterdata + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class CityController : ControllerEntityBase<CityEntity>
    {
        private readonly ICityRepository _repository;
        private readonly ILogger<CityController> _logger;
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

        public CityController(ILogger<CityController> logger, ICityRepository repository, 
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
                var cacheData = await _retryPolicy.ExecuteAsync<IEnumerable<CityEntity>>(
                    async() => await _redisCacheService.GetData<IEnumerable<CityEntity>>(RedisCachingKey.CityListActive));

                if (cacheData != null) return Ok(cacheData);

                Expression<Func<CityEntity, bool>> query = x => x.IsActive == true && x.IsDeleted == false;

                cacheData = await _retryPolicy.ExecuteAsync<IEnumerable<CityEntity>>(
                    async () => await _repository.Filter(query));

                if(cacheData == null) return Ok(null);

                await _retryPolicy.ExecuteAsync<bool>(
                    async () => await _redisCacheService.SetData<IEnumerable<CityEntity>>(RedisCachingKey.CityListActive, cacheData));

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