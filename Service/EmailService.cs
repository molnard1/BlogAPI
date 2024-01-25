using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using MailTest.Models.Dtos;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace MailTest.Service
{
    public class EmailService(IConfiguration configuration) : IEmailService.IEmailService
    {
        public string SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(configuration.GetSection("EmailSettings:EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            StringBuilder builder = new();
            using var smtp = new SmtpClient(new EmailLogger(builder));
            smtp.Connect(configuration.GetSection("EmailSettings:EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(configuration.GetSection("EmailSettings:EmailUserName").Value, configuration.GetSection("EmailSettings:EmailPassword").Value);

            smtp.Send(email);
            smtp.Disconnect(true);

            return builder.ToString();
        }
    }
}