using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechSpace.Domain;
using TechSpace.Services;

namespace TechSpace.Controllers
{
    [ApiController]
    [Route("spaces")]
    public class TechSpacesController : Controller
    {
        private readonly ITechSpacesService _techSpacesService;
        private readonly ITechSpacesPostsService _techSpacesPostsService;

        public TechSpacesController(ITechSpacesService techSpacesService, ITechSpacesPostsService techSpacesPostsService)
        {
            _techSpacesService = techSpacesService;
            _techSpacesPostsService = techSpacesPostsService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> AllSpaces()
        {
            var spaces = await _techSpacesService.GetAll();

            var postsForAllSpaces = new List<TechnologySpacePost>();
            foreach (var space in spaces)
            {
                var postsForSpace = await _techSpacesPostsService.GetPopularPostsForSpace(space);
                postsForAllSpaces.AddRange(postsForSpace);
            }

            return new OkObjectResult(postsForAllSpaces);
        }

        [HttpGet("{name}")]
        public IActionResult GetSpaceByName([FromRoute] string name)
        {
            return new OkResult();
        }
    }
}