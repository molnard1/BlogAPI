namespace BlogAPI.Models
{
    public class BlogUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
    }
}
