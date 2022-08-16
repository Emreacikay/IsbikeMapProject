using JsonWebTokenAPI.Data.Dto;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace JsonWebTokenAPI.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(UserDto user)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("EmailSettings:from"));
            email.To.Add(MailboxAddress.Parse(user.Email));
            email.Subject = "Onay maili";
            email.Body = new TextPart("Lütfen Mailinizi Onaylayın!");

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailSettings:provider").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailSettings:credentials:email").Value, (_config.GetSection("EmailSettings:credentials:passowrd").Value));
            smtp.Send(email);
            smtp.Disconnect(true); ;
        }
    }
}
