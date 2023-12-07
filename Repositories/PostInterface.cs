using BlogAPI.Models;
using BlogAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories
{
    public class PostInterface : IPostInterface
    {
        private readonly BlogContext _dbContext;

        public PostInterface(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<Blogpost>> Get()
        {
            return await _dbContext.Blogposts.ToListAsync();
        }

        public async Task<Blogpost> GetById(Guid id)
        {
            return await _dbContext.Blogposts.FirstAsync(x => x.PostId == id);
        }

        public async Task<Blogpost> Post(CreateBlogPost createBlogPost)
        {
            var post = new Blogpost
            {
                UserId = createBlogPost.Author,
                Title = createBlogPost.Title,
                Content = createBlogPost.Content
            };
            await _dbContext.Blogposts.AddAsync(post);
            await _dbContext.SaveChangesAsync();

            return post;
        }

        public async Task<Blogpost> Put(Guid id, UpdateBlogPost updateBlogPost)
        {
            var existing = await _dbContext.Blogposts.FirstAsync(x => x.PostId == id);
            existing.Content = updateBlogPost.Content;
            existing.Title = updateBlogPost.Title;
            existing.UpdatedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = _dbContext.Blogposts.Where(x => x.PostId == id);

            if (!await existing.AnyAsync()) return false;

            _dbContext.Blogposts.Remove(await existing.FirstAsync());
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
