using MailTest.Models.Dtos;

namespace MailTest.Service.IEmailService
{
    public interface IEmailService
    {
        string SendEmail(EmailDto request);
    }
}
