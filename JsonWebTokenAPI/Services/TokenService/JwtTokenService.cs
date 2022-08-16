using JsonWebTokenAPI.Data.Dto;
using JsonWebTokenAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JsonWebTokenAPI.Services.TokenService
{
    public class JwtTokenService:IJwtTokenService
    {
        public static User user = new User();
        private IConfiguration _configuration;
       

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }

        public string CreateToken(UserLoginDto user)
        {

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(2),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        
    }
}
