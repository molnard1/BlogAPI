using BlogAPI.Models.Dtos;
using BlogUser = BlogAPI.Models.BlogUser;

namespace BlogAPI.Repositories
{
    public interface IBlogUserInterface
    {
        Task<IEnumerable<BlogUser>> Get();
        Task<BlogUser> GetById(Guid id);

        Task<BlogUser> Post(CreateBlogUser createBlogUser);

        Task<BlogUser> Put(Guid id, UpdateBlogUser updateBlogUser);
        Task<bool> Delete(Guid id);
    }
}
