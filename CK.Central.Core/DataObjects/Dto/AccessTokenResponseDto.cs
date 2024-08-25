using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.BearerToken;

namespace CK.Central.Core.DataObjects.Dto
{
    public class AccessTokenResponseDto
    {
        public AccessTokenResponseDto() { }

        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public AccessTokenResponse? accessTokenResponse { get; set; }
        public DateTime? AccessTokenExpiryTime { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? Message { get; set; }
        public TokenResponse? Token { get; set; }
    }
}
