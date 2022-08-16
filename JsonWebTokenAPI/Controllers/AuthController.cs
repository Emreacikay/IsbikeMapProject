using JsonWebTokenAPI.Data.Dto;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using JsonWebTokenAPI.Services.TokenService;
using JsonWebTokenAPI.Models;
using JsonWebTokenAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace JsonWebTokenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DataContext _context;
        private IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IJwtTokenService _jwtTokenService;
        private static readonly HttpClient client = new HttpClient();

        public AuthController(DataContext dataContext, IConfiguration configuration, IUserService userService, IJwtTokenService jwtTokenService) 
        {
            _context = dataContext;
            _configuration = configuration;
            _userService = userService;
            _jwtTokenService = jwtTokenService;
        }


        //Doesn't have any affect at program right now.
        [HttpGet("Role"), Authorize]
        public ActionResult<string> GetMe()
        {
            var role = _userService.GetMyRole();
            return Ok(role);

            //var userName = User?.Identity?.Name;
            //var userName2 = User.FindFirstValue(ClaimTypes.Name);
            //var role = User.FindFirstValue(ClaimTypes.Role);
            //return Ok(new {userName,userName2,role});
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDto request) 
        {
            if (_context.Users.Any(u => u.Email == request.Email)){
                return BadRequest("User already exists.");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Token = "noToken",
            TokenCreated = DateTime.Now,
            TokenExpires = DateTime.Now
           };
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            
            if(user == null )
            {
                return BadRequest("User Not Found.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Email or Password is incorrect.");
            }

            var modelJson = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            var jsonString = new StringContent(modelJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7037/api/Token", jsonString);
            string Token = await response.Content.ReadAsStringAsync();

            
            user.Token = Token;
            user.TokenCreated = DateTime.Now;
            user.TokenExpires = DateTime.Now.AddHours(2);
            await _context.SaveChangesAsync();
            
            
            return Ok(Token);
        }

        private void CreatePasswordHash (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        
    }
}
