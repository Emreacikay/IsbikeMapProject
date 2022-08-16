using JsonWebTokenAPI.Data.Dto;

namespace JsonWebTokenAPI.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(UserDto user);
    }
}
