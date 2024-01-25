using MailTest.Models.Dtos;
using MailTest.Service.IEmailService;
using Microsoft.AspNetCore.Mvc;

namespace MailTest.Controllers
{
    [ApiController]
    [Route("email")]
    public class EmailController(IEmailService emailService) : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            return Ok(emailService.SendEmail(request));
        }
    }
}
