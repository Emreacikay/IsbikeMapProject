using JsonWebTokenAPI.Data;
using JsonWebTokenAPI.Data.Dto;
using JsonWebTokenAPI.Services.TokenService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsonWebTokenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        IJwtTokenService _tokenService;

        public TokenController(IJwtTokenService jwtTokenService) 
        {
            _tokenService = jwtTokenService;
        }

        [HttpPost]
        public IActionResult CreateToken(UserLoginDto user)
        {
            var token = _tokenService.CreateToken(user);
            return Ok(token);
        }
    }
}
