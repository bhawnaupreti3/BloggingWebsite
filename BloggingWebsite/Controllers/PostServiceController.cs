using BloggingWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BloggingWebsite.Controllers
{
    /// <summary>
    /// Controller for Post Http calls
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PostServiceController : ControllerBase
    {

        #region private
        private readonly ILogger<PostServiceController> _logger;
        private readonly IPostService _postService;
        #endregion

        /// <summary>
        /// instance for post service
        /// </summary>
        /// <param name="logger">logger dependecy passed</param>
        /// <param name="postService">post service dependecy passed</param>
        public PostServiceController(ILogger<PostServiceController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;

        }

        #region get post

        /// <summary>
        /// Fetch list of all posts
        /// </summary>
        /// <returns>return posts present</returns>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Searching for Post");
            var posts = _postService.GetAllBlogs();

            _logger.LogInformation("Post Searching Complete");
            return Ok(posts);
        }

        #endregion

        #region add/update post

        /// <summary>
        /// Add/Update Post
        /// </summary>
        /// <param name="post"></param>
        /// <returns>status of operation returned</returns>
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

        #endregion

        #region delete post

        /// <summary>
        /// Deletes post
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _logger.LogInformation("Removing Post from blogging website");
            _postService.Delete(id);
        }
        #endregion
    }
}
