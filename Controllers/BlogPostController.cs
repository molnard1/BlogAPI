using BlogAPI.Models;
using BlogAPI.Models.Dtos;
using BlogAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogPostController : Controller
    {
        private readonly IPostInterface _blogPostInterface;

        public BlogPostController(IPostInterface blogPostInterface)
        {
            _blogPostInterface = blogPostInterface;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateBlogPost post)
        {
            return await _blogPostInterface.Post(post);
        }

        [HttpGet]
        public async Task<ActionResult<List<Blogpost>>> Get()
        {
            return Ok(await _blogPostInterface.Get());
        }

        [HttpGet]
        [Route("/BlogPost/byAuthor/{id:guid}")]
        public async Task<ActionResult<List<Blogpost>>> GetByAuthor(Guid id)
        {
            return Ok(await _blogPostInterface.GetByAuthor(id));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Blogpost>> Get(Guid id)
        {
            try
            {
                return Ok(await _blogPostInterface.GetById(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<Blogpost>> Put(UpdateBlogPost update, Guid id)
        {
            try
            {
                return Ok(await _blogPostInterface.Put(id, update));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await _blogPostInterface.Delete(id) ? Ok() : NotFound();
        }
    }
}
