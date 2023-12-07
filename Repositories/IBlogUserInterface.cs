using BlogAPI.Models.Dtos;

namespace BlogAPI.Repositories
{
    public interface IBlogUserInterface
    {
        Task<IEnumerable<BlogUserDto>> Get();
        Task<BlogUserDto> GetById(Guid id);
        Task<BlogUserDto> Post(CreateBlogUser createBlogUser);

        Task<BlogUserDto> Put(Guid id, UpdateBlogUser updateBlogUser);
        Task<bool> Delete(Guid id);
    }
}
