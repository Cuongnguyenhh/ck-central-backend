using CK.Central.Core.Abstract.Services;
using CK.Central.Core.DataObjects.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace CK.Central.Core.Services
{
    public class JWTokenService : IJWTokenService
    {
        private readonly IConfiguration _configuration;

        public JWTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AccessTokenResponseDto> CreateAccessToken(JwtSecurityToken token)
        {
            AccessTokenResponseDto response = new AccessTokenResponseDto();

            _ = int.TryParse(_configuration.GetSection("JwtTokenSettings:TokenValidityInMinutes").Value, out int tokenValidityInMinutes);
            _ = int.TryParse(_configuration.GetSection("JwtTokenSettings:RefreshTokenValidityInDays").Value, out int refreshTokenValidityInDays);

            var refreshToken = GenerateRefreshToken();
            response.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            response.AccessTokenExpiryTime = DateTime.Now.AddMinutes(tokenValidityInMinutes);
            response.RefreshToken = refreshToken;
            response.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
            response.Message = HttpStatusCode.OK.ToString();

            await Task.WhenAll();

            return response;
        }

        public async Task<RefreshTokenResponseDto> CreateRefreshToken(RefreshTokenRequestDto tokenRequest)
        {
            RefreshTokenResponseDto response = new RefreshTokenResponseDto();

            if (tokenRequest is null)
            {
                response.Message = HttpStatusCode.BadRequest.ToString();
                return response;
            }

            var principal = GetPrincipalFromExpiredToken(tokenRequest.AccessToken);

            if (principal == null)
            {
                response.Message = HttpStatusCode.BadRequest.ToString();
                return response;
            }

            _ = int.TryParse(_configuration.GetSection("JwtTokenSettings:RefreshTokenValidityInDays").Value, 
                out int refreshTokenValidityInDays);

            var token = await CreateRefreshToken(principal.Claims.ToList());
            var newrefreshToken = GenerateRefreshToken();
            response.RefreshToken = newrefreshToken;
            response.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
            response.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            response.Message = HttpStatusCode.OK.ToString();

            await Task.WhenAll();

            return response;
        }

        public async Task<JwtSecurityToken> CreateAccessToken(AccessTokenRequestDto accessTokenRequest)
        {
            if (accessTokenRequest == null) return new JwtSecurityToken();
            if (string.IsNullOrEmpty(accessTokenRequest.Username)) return new JwtSecurityToken();
            if (string.IsNullOrEmpty(accessTokenRequest.Password)) return new JwtSecurityToken();

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JwtTokenSettings:SymmetricSecurityKey").Value));

            var validIssuer = _configuration.GetSection("JwtTokenSettings:ValidIssuer").Value;

            var validAudience = _configuration.GetSection("JwtTokenSettings:ValidAudience").Value;

            _ = int.TryParse(_configuration.GetSection("JwtTokenSettings:TokenValidityInMinutes").Value,
                out int tokenValidityInMinutes);

            var roleClaims = new List<Claim>();

            if (accessTokenRequest.Roles.Count > 0)
                foreach (var role in accessTokenRequest.Roles)
                    roleClaims.Add(new Claim("roles", role));

            var authClaims = new List<Claim>
                        {
                            new Claim("Id", Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Sub, accessTokenRequest.Password),
                            new Claim(JwtRegisteredClaimNames.Email, accessTokenRequest.Email),
                            new Claim(JwtRegisteredClaimNames.Name, accessTokenRequest.Username),
                            new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.Ticks.ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        }.Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            await Task.WhenAll();

            return token;
        }

        public async Task<JwtSecurityToken> CreateRefreshToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JwtTokenSettings:SymmetricSecurityKey").Value));

            var validIssuer = _configuration.GetSection("JwtTokenSettings:ValidIssuer").Value;

            var validAudience = _configuration.GetSection("JwtTokenSettings:ValidAudience").Value;

            _ = int.TryParse(_configuration.GetSection("JwtTokenSettings:TokenValidityInMinutes").Value,
                out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            await Task.WhenAll();

            return token;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            if (string.IsNullOrEmpty(token)) return new ClaimsPrincipal();

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JwtTokenSettings:SymmetricSecurityKey").Value));

            var validIssuer = _configuration.GetSection("JwtTokenSettings:ValidIssuer").Value;

            var validAudience = _configuration.GetSection("JwtTokenSettings:ValidAudience").Value;

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidAudience = validAudience,
                ValidIssuer = validIssuer,
                IssuerSigningKey = authSigningKey
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public string GenerateJwt(AccessTokenRequestDto accessTokenRequest)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JwtTokenSettings:SymmetricSecurityKey").Value));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var validIssuer = _configuration.GetSection("JwtTokenSettings:ValidIssuer").Value;

            var validAudience = _configuration.GetSection("JwtTokenSettings:ValidAudience").Value;

            _ = int.TryParse(_configuration.GetSection("JwtTokenSettings:TokenValidityInMinutes").Value,
                out int tokenValidityInMinutes);

            var roleClaims = new List<Claim>();

            if (accessTokenRequest.Roles.Count > 0)
                foreach (var role in accessTokenRequest.Roles)
                    roleClaims.Add(new Claim("roles", role));

            var claims = new[] {
                            new Claim("Id", Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Sub, accessTokenRequest.Password),
                            new Claim(JwtRegisteredClaimNames.Email, accessTokenRequest.Email),
                            new Claim(JwtRegisteredClaimNames.Name, accessTokenRequest.Username),
                            new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.Ticks.ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(roleClaims);

            var token = new JwtSecurityToken(validIssuer,
                validAudience,
                claims,
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
