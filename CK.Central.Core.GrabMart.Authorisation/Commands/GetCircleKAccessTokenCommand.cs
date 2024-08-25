using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Authorisation.Abstract.Repositories;
using CK.Central.Core.GrabMart.Authorisation.Abstract.Services;
using CK.Central.Core.Domain.CMS.Constants;
using MediatR;
using Polly;
using Polly.Retry;
using CK.Central.Core.DataObjects.Dto;
using System.Net;
using CK.Central.Core.Domain.DataObjects.GrabMart.Request;
using CK.Central.Core.Abstract.Services;
using Microsoft.AspNetCore.Authentication.BearerToken;

namespace CK.Central.Core.GrabMart.Authorisation.Commands
{
    public class GetCircleKAccessTokenCommand : PartnerOAuthTokenRequestDto, IRequest<PartnerOAuthTokenResponseDto>
    {
        public GetCircleKAccessTokenCommand()
        { }
    }

    public class GetCircleKAccessTokenCommandHandler : IRequestHandler<GetCircleKAccessTokenCommand, PartnerOAuthTokenResponseDto>
    {
        private readonly IAuthorisationTokenRepository _repository;
        private readonly IRedisCacheGrabMartAuthorisationService _redisCacheService;
        private readonly IHttpClientGrabMartAuthorisationService _httpClientService;
        private readonly IJWTokenService _jWTokenService;
        private AsyncRetryPolicy _retryPolicy;

        public GetCircleKAccessTokenCommandHandler(IAuthorisationTokenRepository repository,
            IRedisCacheGrabMartAuthorisationService redisCacheService,
            IHttpClientGrabMartAuthorisationService httpClientService,
            IJWTokenService jWTokenService
            )
        {
            _repository = repository;
            _redisCacheService = redisCacheService;
            _retryPolicy = Policy.Handle<Exception>().WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)));
            _httpClientService = httpClientService;
            _jWTokenService = jWTokenService;
        }

        public async Task<PartnerOAuthTokenResponseDto> Handle(GetCircleKAccessTokenCommand request, CancellationToken cancellationToken)
        {
            AccessTokenResponseDto accessTokenResponse = new AccessTokenResponseDto();

            var cacheLink = await _retryPolicy.ExecuteAsync<IEnumerable<LinkEntity>>(
                    async () => await _redisCacheService.GetData<IEnumerable<LinkEntity>>(RedisCachingKey.LinkListActive));

            var cacheToken = await _retryPolicy.ExecuteAsync<IEnumerable<TokenEntity>>(
                    async () => await _redisCacheService.GetData<IEnumerable<TokenEntity>>(RedisCachingKey.TokenListActive));

            if (cacheLink != null && cacheLink != null)
            {
                var link = cacheLink.Where(x => x.Code == "").FirstOrDefault() as LinkEntity;
                var token = cacheToken.Where(x => x.Code == "TK005").FirstOrDefault() as TokenEntity;

                if (request.client_id?.Trim() == token?.ClientId?.Trim() && request.client_secret?.Trim() == token?.ClientSecret?.Trim())
                {
                    AccessTokenRequestDto accessTokenRequest = new AccessTokenRequestDto()
                    {
                        Username = request?.client_id?.Trim(),
                        Email = string.Empty,
                        Password = request?.client_secret?.Trim(),
                        Roles = new List<string> { token.Scope?.Trim() }
                    };

                    var tokenAccess = await _jWTokenService.CreateAccessToken(accessTokenRequest);
                    accessTokenResponse = await _jWTokenService.CreateAccessToken(tokenAccess);
                }
                else
                {
                    accessTokenResponse.Message = HttpStatusCode.BadRequest.ToString();
                    return new PartnerOAuthTokenResponseDto { access_token = string.Empty, token_type = string.Empty, expires_in = 0 };
                }
            }
            else
            {
                return new PartnerOAuthTokenResponseDto { access_token = string.Empty, token_type = string.Empty, expires_in = 0 };
            }

            return new PartnerOAuthTokenResponseDto { access_token = accessTokenResponse.AccessToken, token_type = "Bearer", expires_in = 0 };
        }
    }
}
