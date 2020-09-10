using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechSpace.Services;
using TechSpace.Web.Services;

namespace TechSpace.Controllers
{
    [ApiController]
    [Route("spaces")]
    public class TechSpacesController : Controller
    {
        private readonly ITechSpacesService _techSpacesService;
        private readonly IPostsService _postsService;

        public TechSpacesController(ITechSpacesService techSpacesService, IPostsService postsService)
        {
            _techSpacesService = techSpacesService;
            _postsService = postsService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> AllSpaces()
        {
            var spaces = await _techSpacesService.GetAll();
            return new OkObjectResult(spaces);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetSpaceByName([FromRoute] string name)
        {
            var space = await _techSpacesService.Get(name);
            return new OkObjectResult(space);
        }
    }
}
