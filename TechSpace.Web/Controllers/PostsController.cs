using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechSpace.Web.Models;
using TechSpace.Web.Services;

namespace TechSpace.Web.Controllers
{
    [ApiController]
    public class PostsController
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        [Route("posts/{provider}/{id}")]
        public async Task<IActionResult> GetPostById(
            [FromRoute] FeedProvider provider,
            [FromRoute] string id)
        {
            return new OkObjectResult(await _postsService.GetPostsById(id, provider));
        }
    }
}