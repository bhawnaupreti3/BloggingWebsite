using BloggingWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BloggingWebsite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostServiceController : ControllerBase
    {
        
        private readonly ILogger<PostServiceController> _logger;
        private readonly IPostService _postService;
        public PostServiceController(ILogger<PostServiceController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Searching for Post");
            var posts = _postService.GetAllBlogs();

            _logger.LogInformation("Post Searching Complete");
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Post post)
        {
            _logger.LogInformation("Adding Post to blogging website");
            
            _postService.Add(post);
            if (await _postService.SaveChangesAsync())
            {
                _logger.LogInformation("Post added successfully to blogging website");
                return Ok();
            }
            else
            {
                _logger.LogInformation("Post could not be added successfully blogging website");
                return NotFound();
            }
                
                
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _logger.LogInformation("Removing Post from blogging website");
            _postService.Delete(id);
        }
    }
}
