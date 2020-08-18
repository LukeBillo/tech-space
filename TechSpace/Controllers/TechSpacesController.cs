using Microsoft.AspNetCore.Mvc;

namespace TechSpace.Controllers
{
    public class TechSpacesController : Controller
    {
        public TechSpacesController(ITechSpacesService techSpacesService)
        {
            
        }

        [HttpGet("all")]
        public IActionResult AllSpaces()
        {
            return new OkResult();
        }

        [HttpGet("{name}")]
        public IActionResult GetSpaceByName([FromRoute] string name)
        {
            return new OkResult();
        }
    }
}