namespace BlogAPI.Models;

public class Blogpost
{
    public Guid UserId { get; set; }

    public Guid PostId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual BlogUser User { get; set; } = null!;
}
