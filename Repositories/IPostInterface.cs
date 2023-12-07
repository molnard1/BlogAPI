using BlogAPI.Models;
using BlogAPI.Models.Dtos;

namespace BlogAPI.Repositories
{
    public interface IPostInterface
    {
        Task<IEnumerable<Blogpost>> Get();
        Task<Blogpost> GetById(Guid id);
        Task<Blogpost> Post(CreateBlogPost createBlogPost);
        Task<Blogpost> Put(Guid id, UpdateBlogPost updateBlogPost);
        Task<bool> Delete(Guid id);
    }
}
