namespace BlogAPI.Models.Dtos
{
    public record BlogUserDto(Guid Id, string Username, string UserEmail, string Password, DateTime CreatedTime);

    public record CreateBlogUser(string Username, string UserEmail, string Password);

    public record UpdateBlogUser(string Username, string UserEmail, string Password);

    public record CreateBlogPost(Guid Author, string Title, string Content);

    public record UpdateBlogPost(string Title, string Content);
}
