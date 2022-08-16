using JsonWebTokenAPI.Data.Dto;

namespace JsonWebTokenAPI.Services.TokenService
{
    public interface IJwtTokenService
    {
        public string CreateToken(UserLoginDto user);
    }
}
