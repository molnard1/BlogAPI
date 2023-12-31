﻿using BlogAPI.Models;
using BlogAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<Blogpost>> GetByAuthor(Guid id)
        {
            return await _dbContext.Blogposts.Where(x => x.User.Id == id).ToListAsync();
        }

        public async Task<ActionResult> Post(CreateBlogPost createBlogPost)
        {
            if (await _dbContext.Blogusers.CountAsync(x => x.Id == createBlogPost.Author) == 0)
            {
                return new BadRequestObjectResult("Nem létezik a megadott felhasználó!");
            }

            var post = new Blogpost
            {
                UserId = createBlogPost.Author,
                Title = createBlogPost.Title,
                Content = createBlogPost.Content
            };
            await _dbContext.Blogposts.AddAsync(post);
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(post);
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
