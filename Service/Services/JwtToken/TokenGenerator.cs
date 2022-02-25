using Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.JwtToken
{
    public class TokenGenerator
    {
        private readonly IConfiguration _configuration;
        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Token CreateToken(User user)
        {
            Token token = new Token();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience:_configuration["Jwt:Audience"],
                expires:DateTime.Now.AddHours(2),
                notBefore:DateTime.Now,
                signingCredentials: signingCredentials,
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim("UserId",user.Id.ToString())
                }
                );
            
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string accessToken = tokenHandler.WriteToken(securityToken);
            token.AccessToken = accessToken;
            token.RefreshToken = Guid.NewGuid().ToString();
            return token;
        }
    }
}
