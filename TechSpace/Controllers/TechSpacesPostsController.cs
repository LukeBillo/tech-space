using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechSpace.Domain;
using TechSpace.Services;

namespace TechSpace.Controllers
{
    [Route("spaces/{name}/posts")]
    public class TechSpacesPostsController
    {
        private readonly ITechSpacesService _techSpacesService;
        private readonly ITechSpacesPostsService _techSpacesPostsService;

        public TechSpacesPostsController(ITechSpacesService techSpacesService, ITechSpacesPostsService techSpacesPostsService)
        {
            _techSpacesService = techSpacesService;
            _techSpacesPostsService = techSpacesPostsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostsForSpace([FromRoute] string name)
        {
            if (name == "popular")
            {
                var popularPostsForAllSpaces = await GetPopularPosts();
                return new OkObjectResult(popularPostsForAllSpaces);
            }
            
            var space = await _techSpacesService.Get(name);
            var postsForSpace = await _techSpacesPostsService.GetPopularPostsForSpace(space);
            return new OkObjectResult(postsForSpace);
        }

        private async Task<List<TechnologySpacePost>> GetPopularPosts()
        {
            var spaces = await _techSpacesService.GetAll();
            var postsForAllSpaces = new List<TechnologySpacePost>();
            
            foreach (var space in spaces)
            {
                var postsForSpace = await _techSpacesPostsService.GetPopularPostsForSpace(space);
                postsForAllSpaces.AddRange(postsForSpace);
            }

            return postsForAllSpaces;
        }
    }
}