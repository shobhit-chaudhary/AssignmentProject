



using BlogManagement.Models;
using BlogManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BlogPost>> GetBlogPosts()
        {
            return Ok(_blogService.GetAllBlogPosts());
        }

        [HttpGet("{id}")]
        public ActionResult<BlogPost> GetBlogPost(int id)
        {
            var post = _blogService.GetBlogPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public ActionResult<BlogPost> CreateBlogPost([FromBody] BlogPost newPost)
        {
            var createdPost = _blogService.AddBlogPost(newPost);
            return CreatedAtAction(nameof(GetBlogPost), new { id = createdPost.Id }, createdPost);
        }

        [HttpPut("{id}")]
        public ActionResult<BlogPost> UpdateBlogPost(int id, [FromBody] BlogPost updatedPost)
        {
            var post = _blogService.UpdateBlogPost(id, updatedPost);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBlogPost(int id)
        {
            _blogService.DeleteBlogPost(id);
            return NoContent();
        }
    }
}

