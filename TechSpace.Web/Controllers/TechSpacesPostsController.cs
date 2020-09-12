using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechSpace.Web.Models;
using TechSpace.Web.Services;

namespace TechSpace.Web.Controllers
{
    [Route("spaces/{name}/posts")]
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
        public async Task<IActionResult> GetPostsForSpace([FromRoute] string name)
        {
            if (name == "popular")
            {
                var popularPostsForAllSpaces = await GetPopularPosts();
                return new OkObjectResult(popularPostsForAllSpaces);
            }
            
            var space = await _techSpacesService.Get(name);
            var postsForSpace = await _postsService.GetPopularPostsForSpace(space);
            return new OkObjectResult(postsForSpace);
        }

        private async Task<List<Post>> GetPopularPosts()
        {
            var spaces = await _techSpacesService.GetAll();
            var postsForAllSpaces = new List<Post>();
            
            foreach (var space in spaces)
            {
                var postsForSpace = await _postsService.GetPopularPostsForSpace(space);
                postsForAllSpaces.AddRange(postsForSpace);
            }

            return postsForAllSpaces;
        }
    }
}