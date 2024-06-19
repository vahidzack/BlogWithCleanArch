using Blog.Application.Blogs.Commands.Createblog;
using Blog.Application.Blogs.Commands.DeleteBlog;
using Blog.Application.Blogs.Commands.UpdateBlog;
using Blog.Application.Blogs.Queries.GetBlogs;
using Blog.Application.Blogs.Queries.GetBlogsById;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await Mediator.Send(new GetBlogQuery());
            return Ok(blogs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBlogsById(int Id)
        {
            var blogs = await Mediator.Send(new GetblogByIdQuery() { BlogId = Id });
            if (blogs == null)
            {
                return NotFound("the blog not found");
            }
            return Ok(blogs);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBlog([FromForm] CreateBlogCommand blogCommand)
        {
            var blogDTO = await Mediator.Send(blogCommand);
            return CreatedAtAction(nameof(GetBlogsById), new { id = blogDTO.Id }, blogDTO);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBlog([FromForm] UpdateBlogCommand blogCommand)
        {
            if (blogCommand.Id == null)
            {
                return BadRequest("The blog Not Exist");
            }
            await Mediator.Send(blogCommand);
            return Ok("the Blog Updated");

        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var command = new DeleteBlogCommand { Id = id };
            var result = await Mediator.Send(command);

            if (result > 0)
            {
                return Ok("The Blog Deleted"); 
            }
            else
            {
                return NotFound(); 
            }
        }
    }
}
