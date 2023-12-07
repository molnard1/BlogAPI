using BlogAPI.Models;
using BlogAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using BlogUser = BlogAPI.Models.BlogUser;

namespace BlogAPI.Repositories
{
    public class BlogUserService : IBlogUserInterface
    {
        private readonly BlogContext _dbContext;

        public BlogUserService(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<BlogUser>> Get()
        {
            return await _dbContext.Blogusers.ToListAsync();
        }

        public async Task<BlogUser> GetById(Guid id)
        {
            return await _dbContext.Blogusers.FirstAsync(x => x.Id == id);
        }

        public async Task<BlogUser> Post(CreateBlogUser createBlogUser)
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

            return user;
        }

        public async Task<BlogUser> Put(UpdateBlogUser updateBlogUser)
        {
            var existing = await _dbContext.Blogusers.FirstAsync(x => x.Id == updateBlogUser.Id);
            existing.Username = updateBlogUser.Username;
            existing.UserEmail = updateBlogUser.UserEmail;
            existing.Password = updateBlogUser.Password;
            await _dbContext.SaveChangesAsync();
            return existing;

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
