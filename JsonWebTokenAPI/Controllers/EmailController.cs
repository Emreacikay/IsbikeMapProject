using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MailKit;
using JsonWebTokenAPI.Data.Dto;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace JsonWebTokenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(UserDto user)
        {
            _emailService.SendEmail(user);
            return Ok();
        }
    }
}
