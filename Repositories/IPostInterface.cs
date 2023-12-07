using BlogAPI.Models;
using BlogAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Repositories
{
    public interface IPostInterface
    {
        Task<IEnumerable<Blogpost>> Get();
        Task<Blogpost> GetById(Guid id);
        Task<List<Blogpost>> GetByAuthor(Guid id);
        Task<ActionResult> Post(CreateBlogPost createBlogPost);
        Task<Blogpost> Put(Guid id, UpdateBlogPost updateBlogPost);
        Task<bool> Delete(Guid id);
    }
}
