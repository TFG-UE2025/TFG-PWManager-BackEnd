using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TFG.PWManager.BackEnd.Domain.Extensions;
using TFG.PWManager.BackEnd.Domain.Models;
using TFG.PWManager.BackEnd.Jwt.Contracts;

namespace TFG.PWManager.BackEnd.Jwt.Services
{
    public class JwtService : IJwtService
    {
        public JwtResponseModel GenerateJwt(JwtRequestModel request)
        {
            var email = string.IsNullOrEmpty(request.Email) ? string.Empty : request.Email;
            var secretKey = string.IsNullOrEmpty(request.SecretKey) ? string.Empty : request.SecretKey;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Email, email),
            };

            if (request.Claims != null && request.Claims.Any())
            {
                claims = claims.Union(request.Claims).ToArray();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var currentDt = DateTime.UtcNow.ConvertDateTime();
            var expires = currentDt.AddMinutes(request.ExpirationMinutes);

            var token = new JwtSecurityToken(
                issuer: request.Issuer,
                audience: request.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new JwtResponseModel()
            {
                AccessToken = accessToken,
                Email = email,
                ExpiredDate = expires.ConvertDateTime(tzTargetId: request.TzId!).ToString("dd/MM/yyyy HH:mm:ss.fff")
            };
        }
    }
}
