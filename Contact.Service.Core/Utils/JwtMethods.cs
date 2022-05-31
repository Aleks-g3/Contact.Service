using Contact.Service.Core.Models;
using Contact.Service.Core.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Core.Utils
{
    public class JwtMethods
    {
        public static string GenerateJwt(User user, AuthenticationSettings authenticationSettings)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.Name} {user.Surname}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey));
            var cred= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(authenticationSettings.JwtIssuer, authenticationSettings.JwtIssuer, 
                claims, 
                expires: expires, 
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
