namespace MailTest.Models
{
    public class Email
    {
        public Guid Id { get; set; }
        public string To { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}
