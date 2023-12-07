namespace BlogAPI.Models.Dtos
{
    public record BlogUser(Guid Id, string Username, string UserEmail, string Password, DateTime CreatedTime);

    public record CreateBlogUser(string Username, string UserEmail, string Password);

    public record UpdateBlogUser(Guid Id, string Username, string UserEmail, string Password);
}
