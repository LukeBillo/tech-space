using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechSpace.Web.Services;

namespace TechSpace.Web.Controllers
{
    [ApiController]
    public class SpacesController : Controller
    {
        private readonly ITechSpacesService _techSpacesService;
        private readonly IPostsService _postsService;

        public SpacesController(ITechSpacesService techSpacesService, IPostsService postsService)
        {
            _techSpacesService = techSpacesService;
            _postsService = postsService;
        }

        [HttpGet("spaces/all")]
        public async Task<IActionResult> AllSpaces()
        {
            var spaces = await _techSpacesService.GetAll();
            return new OkObjectResult(spaces);
        }

        [HttpGet("spaces/{name}")]
        public async Task<IActionResult> GetSpaceByName([FromRoute] string name)
        {
            var space = await _techSpacesService.Get(name);
            return new OkObjectResult(space);
        }
        
        [HttpGet]
        [Route("spaces/{name}/posts")]
        public async Task<IActionResult> GetPostsForSpace([FromRoute] string name)
        {
            var space = await _techSpacesService.Get(name);
            var postsForSpace = await _postsService.GetPopularPostsForSpace(space);
            return new OkObjectResult(postsForSpace);
        }
    }
}
