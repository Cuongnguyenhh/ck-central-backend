using CK.Central.Core.CMS.MasterData.Abstract.Repositories;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.CMS.Constants;
using Microsoft.AspNetCore.Mvc;
using CK.Central.Core.Domain.DataObjects.CMS.Request;
using CK.Central.Core.Domain.DataObjects.CMS.Response;
using CK.Central.Core.CMS.MasterData.Abstract.Services;
using CK.Central.Core.Controllers;
using Grpc.Net.Client.Configuration;
using Polly;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retry;
using Polly.Timeout;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.OpenApi.Exceptions;
using CK.Central.Core.Constants;
using Asp.Versioning;

namespace CK.Central.API.CMS.MasterData.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckcmsmasterdata + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class GroupController : ControllerEntityBase<GroupEntity>
    {
        private readonly IGroupRepository _repository;
        private readonly ILogger<GroupController> _logger;
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

        public GroupController(ILogger<GroupController> logger, IGroupRepository repository,
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

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertActionAsync([FromForm]GroupRequestDto model)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);

                var obj = new GroupEntity{PK_UUID = Guid.NewGuid(), IsActive = true, IsDeleted = false, CreatedBy = string.Empty, CreatedDatetime = DateTime.Now };

                obj.Name = model.Name;
                obj.Description = model.Description;
                obj.Code = model.Code;

                var pk_uuid = await _repository.Insert(obj);

                return Ok(GroupResponseDto.Succeed(obj));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateActionAsync([FromForm] GroupRequestDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var obj = new GroupEntity { IsActive = true, IsDeleted = false, CreatedBy = string.Empty, CreatedDatetime = DateTime.Now };

                var pk_uuid = await _repository.Update(obj);

                return Ok(GroupResponseDto.Succeed(obj));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetActionAsync()
        {
            try
            {
                var result = await _repository.GetAll();
                return Ok(GroupResponseDto.Succeed(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            try
            {
                var cacheData = await _retryPolicy.ExecuteAsync<IEnumerable<GroupEntity>>(
                    async () => await _redisCacheService.GetData<IEnumerable<GroupEntity>>(RedisCachingKey.GroupListActive));

                if (cacheData != null) return Ok(cacheData);

                Expression<Func<GroupEntity, bool>> query = x => x.IsActive == true && x.IsDeleted == false;

                cacheData = await _retryPolicy.ExecuteAsync<IEnumerable<GroupEntity>>(
                    async () => await _repository.Filter(query));

                if (cacheData == null) return Ok(null);

                await _retryPolicy.ExecuteAsync<bool>(
                    async () => await _redisCacheService.SetData<IEnumerable<GroupEntity>>(RedisCachingKey.GroupListActive, cacheData));

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
