using Asp.Versioning;
using CK.Central.Core.Abstract.Services;
using CK.Central.Core.Constants;
using CK.Central.Core.Controllers;
using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.POS.Entity;
using CK.Central.Core.Domain.DataObjects.POS.Request;
using CK.Central.Core.Domain.DataObjects.POS.Response;
using CK.Central.Core.POS.Abstract.Services;
using Grpc.Net.Client.Configuration;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Exceptions;
using Polly;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retry;
using Polly.Timeout;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CK.Central.API.POS.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route(ApiSubdomainRoute.ckpos + "/api/[controller]")]
    [EnableRateLimiting("sliding")]
    public class SecurityController : Controller
    {
        private readonly IAppSettingService _appSettingService;
        private readonly ILogger<HomeController> _logger;
        private readonly IElasticsearchPOSService _elasticsearchService;
        private readonly IRedisCachePOSService _redisCacheService;
        private readonly IKafkaProducerPOSService _kafkaProducerService;
        private readonly IJWTokenService _jWTokenService;

        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly AsyncTimeoutPolicy _timeoutPolicy;
        private readonly AsyncFallbackPolicy _fallbackPolicy;
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly AsyncBulkheadPolicy _bulkheadPolicy;
        private readonly AsyncRateLimitPolicy _ratelimitPolicy;
        private readonly HedgingPolicy _hedgingPolicy;

        public SecurityController(ILogger<HomeController> logger,
            IAppSettingService appSettingService,
            IJWTokenService jWTokenService,
            IElasticsearchPOSService elasticsearchService,
            IRedisCachePOSService redisCacheService,
            IKafkaProducerPOSService kafkaProducerService
            )
        {
            _logger = logger;
            _appSettingService = appSettingService;
            _jWTokenService = jWTokenService;
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

        [AllowAnonymous]
        [HttpPost]
        [Route("/token")]
        public async Task<AccessTokenResponseDto> Token(AccessTokenRequestDto accessTokenRequest)
        {
            AccessTokenResponseDto response = new AccessTokenResponseDto();

            try
            {
                if (accessTokenRequest.Username == "admin" && accessTokenRequest.Password == "admin")
                {
                    var token = await _jWTokenService.CreateAccessToken(accessTokenRequest);
                    response = await _jWTokenService.CreateAccessToken(token);
                    return response;
                }
                else
                {
                    response.Message = HttpStatusCode.BadRequest.ToString();
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<RefreshTokenResponseDto> RefreshToken(RefreshTokenRequestDto tokenRequest)
        {
            return await _jWTokenService.CreateRefreshToken(tokenRequest);
        }
    }
}
