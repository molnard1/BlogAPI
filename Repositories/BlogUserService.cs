using BlogAPI.Models;
using BlogAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories
{
    public class BlogUserService : IBlogUserInterface
    {
        private readonly BlogContext _dbContext;

        public BlogUserService(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<BlogUserDto>> Get()
        {
            return await _dbContext.Blogusers.Select(x => x.AsDto()).ToListAsync();
        }

        public async Task<BlogUserDto> GetById(Guid id)
        {
            return (await _dbContext.Blogusers.FirstAsync(x => x.Id == id)).AsDto();
        }

        public async Task<BlogUserDto> Post(CreateBlogUser createBlogUser)
        {
            var user = new BlogUser
            {
                Id = Guid.NewGuid(),
                Username = createBlogUser.Username,
                UserEmail = createBlogUser.UserEmail,
                Password = createBlogUser.Password,
                CreatedTime = DateTime.UtcNow
            };
            await _dbContext.Blogusers.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.AsDto();
        }

        public async Task<BlogUserDto> Put(Guid id, UpdateBlogUser updateBlogUser)
        {
            var existing = await _dbContext.Blogusers.FirstAsync(x => x.Id == id);
            existing.Username = updateBlogUser.Username;
            existing.UserEmail = updateBlogUser.UserEmail;
            existing.Password = updateBlogUser.Password;
            await _dbContext.SaveChangesAsync();
            return existing.AsDto();

        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = _dbContext.Blogusers.Where(x => x.Id == id);

            if (!await existing.AnyAsync()) return false;

            _dbContext.Blogusers.Remove(await existing.FirstAsync());
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
