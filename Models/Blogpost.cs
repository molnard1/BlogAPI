namespace BlogAPI.Models;

public class Blogpost
{
    public Guid UserId { get; set; }

    public int PostId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public virtual BlogUser User { get; set; } = null!;
}
