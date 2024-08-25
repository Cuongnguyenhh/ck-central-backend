using CK.Central.Core.DataObjects.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Abstract.Services
{
    public interface IJWTokenService
    {
        Task<AccessTokenResponseDto> CreateAccessToken(JwtSecurityToken token);
        Task<RefreshTokenResponseDto> CreateRefreshToken(RefreshTokenRequestDto tokenRequest);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
        Task<JwtSecurityToken> CreateAccessToken(AccessTokenRequestDto accessTokenRequest);
        Task<JwtSecurityToken> CreateRefreshToken(List<Claim> authClaims);
        string GenerateRefreshToken();
        string GenerateJwt(AccessTokenRequestDto accessToken);
    }
}
