
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Config;
using Microsoft.IdentityModel.Tokens;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.FLEETMANAGEMENT.Backend.Core.Handlers
{
    public class AuthTokenHandler
    {
        public string GenerateTokenAsync(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfig.JwtConfiguration.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var idClaim = new Claim("UserId", user.Id.ToString());
            var userEmailClaim = new Claim("UserEmail", user.Email);
            var roleClaim = new Claim(ClaimTypes.Role, "Admin");

            var claims = new List<Claim> { idClaim, userEmailClaim, roleClaim };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Audience = AppConfig.JwtConfiguration.Audience,
                Issuer = AppConfig.JwtConfiguration.Issuer,
                Expires = DateTime.Now.AddMonths(AppConfig.JwtConfiguration.JwtLifetimeInMonths)
            };

            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
