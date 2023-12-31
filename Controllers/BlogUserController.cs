﻿using BlogAPI.Models.Dtos;
using BlogAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogUserController : Controller
    {
        private readonly IBlogUserInterface _blogUserInterface;

        public BlogUserController(IBlogUserInterface blogUserInterface)
        {
            _blogUserInterface = blogUserInterface;
        }

        [HttpPost]
        public async Task<ActionResult<BlogUserDto>> Post(CreateBlogUser user)
        {
            return StatusCode(201, await _blogUserInterface.Post(user));
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogUserDto>>> Get()
        {
            return Ok(await _blogUserInterface.Get());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<List<BlogUserDto>>> Get(Guid id)
        {
            try
            {
                return Ok(await _blogUserInterface.GetById(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<List<BlogUserDto>>> Put(UpdateBlogUser update, Guid id)
        {
            try
            {
                return Ok(await _blogUserInterface.Put(id, update));
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
            return await _blogUserInterface.Delete(id) ? Ok() : NotFound();
        }
    }
}
