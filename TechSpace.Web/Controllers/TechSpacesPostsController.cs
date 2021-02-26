using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechSpace.Web.Models;
using TechSpace.Web.Services;

namespace TechSpace.Web.Controllers
{
    [ApiController]
    public class TechSpacesPostsController
    {
        private readonly ITechSpacesService _techSpacesService;
        private readonly IPostsService _postsService;

        public TechSpacesPostsController(ITechSpacesService techSpacesService, IPostsService postsService)
        {
            _techSpacesService = techSpacesService;
            _postsService = postsService;
        }

        [HttpGet]
        [Route("spaces/{name}/posts")]
        public async Task<IActionResult> GetPostsForSpace([FromRoute] string name)
        {
            var space = await _techSpacesService.Get(name);
            var postsForSpace = await _postsService.GetPopularPostsForSpace(space);
            return new OkObjectResult(postsForSpace);
        }

        [HttpGet]
        [Route("spaces/{name}/posts/{provider}/{id}")]
        public async Task<IActionResult> GetPostById(
            [FromRoute] string name,
            [FromRoute] FeedProvider provider,
            [FromRoute] string id)
        {
            var space = await _techSpacesService.Get(name);
            return new OkObjectResult(await _postsService.GetPostsById(id, space.Identifier, provider));
        }
    }
}