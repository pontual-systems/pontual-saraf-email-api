using EmailAPI.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        protected readonly IConfiguration _configuration;

        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost(Name = "SendEmail")]
        public async void Post([FromBody] Email email)
        {
            var apiKey = _configuration.GetSection("SendGrid")["key"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_configuration.GetSection("SendGrid")["senderEmail"], _configuration.GetSection("SendGrid")["senderName"]);
            var subject = email.Subject;
            var to = new EmailAddress(email.RecipientEmail, email.RecipientName);
            var htmlContent = email.HtmlBody;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, string.Empty, htmlContent);
            
            await client.SendEmailAsync(msg);
        }
    }
}
