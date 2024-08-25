using CK.Central.Core.Abstract.Services;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Request;
using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Authorisation.Abstract.Repositories;
using CK.Central.Core.GrabMart.Authorisation.Abstract.Services;
using CK.Central.Core.Domain.CMS.Constants;
using CK.Central.Core.Domain.GrabMart.Constants;
using MediatR;
using Polly;
using Polly.Retry;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace CK.Central.Core.GrabMart.Authorisation.Commands
{
    public class GetGrabMartAccessTokenCommand : GrabOAuthTokenRequestDto, IRequest<GrabOAuthTokenResponseDto>
    {
        public GetGrabMartAccessTokenCommand()
        { }
    }

    public class GetGrabMartAccessTokenCommandHandler : IRequestHandler<GetGrabMartAccessTokenCommand, GrabOAuthTokenResponseDto>
    {
        private readonly IAuthorisationTokenRepository _repository;
        private readonly IRedisCacheGrabMartAuthorisationService _redisCacheService;
        private readonly IHttpClientGrabMartAuthorisationService _httpClientService;
        private readonly IJWTokenService _jWTokenService;
        private AsyncRetryPolicy _retryPolicy;

        public GetGrabMartAccessTokenCommandHandler(IAuthorisationTokenRepository repository,
            IRedisCacheGrabMartAuthorisationService redisCacheService,
            IHttpClientGrabMartAuthorisationService httpClientService,
            IJWTokenService jWTokenService)
        {
            _repository = repository;
            _redisCacheService = redisCacheService;
            _retryPolicy = Policy.Handle<Exception>().WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)));
            _httpClientService = httpClientService;
            _jWTokenService = jWTokenService;
        }

        public async Task<GrabOAuthTokenResponseDto> Handle(GetGrabMartAccessTokenCommand request, CancellationToken cancellationToken)
        {
            var cacheLinkListActive = await _retryPolicy.ExecuteAsync<IEnumerable<LinkEntity>>(
                    async () => await _redisCacheService.GetData<IEnumerable<LinkEntity>>(Domain.CMS.Constants.RedisCachingKey.LinkListActive));

            var cacheTokenListActive = await _retryPolicy.ExecuteAsync<IEnumerable<TokenEntity>>(
                    async () => await _redisCacheService.GetData<IEnumerable<TokenEntity>>(Domain.CMS.Constants.RedisCachingKey.TokenListActive));

            var cacheGrabOAuthToken = await _retryPolicy.ExecuteAsync<GrabOAuthTokenResponseDto>(
                    async () => await _redisCacheService.GetData<GrabOAuthTokenResponseDto>(Domain.GrabMart.Constants.RedisCachingKey.AuthorisationGrabmartAccessToken));

            if(cacheGrabOAuthToken != null)
            {
                return cacheGrabOAuthToken;
            }

            if (cacheLinkListActive != null && cacheTokenListActive != null)
            {
                var link = cacheLinkListActive.Where(x => x.Code == "").FirstOrDefault() as LinkEntity;
                var token = cacheTokenListActive.Where(x => x.Code == "TK005").FirstOrDefault() as TokenEntity;

                var data = JsonContent.Create(new
                {
                    client_id = token.ClientId,
                    client_secret = token.ClientSecret,
                    grant_type = token.GrantType,
                    scope = token.Scope
                });

                var messResponse = _httpClientService.Post(token.Uri, data);
                if (messResponse != null)
                {
                    if (messResponse.IsCompletedSuccessfully)
                    {
                        var responseContent = await messResponse.Result.Content.ReadAsStringAsync();

                        var tokenObj = JsonConvert.DeserializeObject<GrabOAuthTokenResponseDto>(responseContent);

                        if(tokenObj != null)
                        {
                            _redisCacheService.SetData(Domain.GrabMart.Constants.RedisCachingKey.AuthorisationGrabmartAccessToken, tokenObj);
                            return tokenObj;
                        }
                    }
                }
            }

            return new GrabOAuthTokenResponseDto();
        }
    }
}
