using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class JwtAuthentication : IJwtAuthentication
    {
        private readonly string _key;
        private readonly UserManager<User> _userManager;

        public JwtAuthentication(string key)
        {
            _key = key;
        }
        

        public async Task<string> AuthenticateAsync(User user)
        {
            //bir kullanici var mi
            var userModel = await _userManager.FindByEmailAsync(user.Email);
            if (userModel is null)
                return null;
            //var user = await _userManager.FindByEmailAsync(user.Email);
            

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}

