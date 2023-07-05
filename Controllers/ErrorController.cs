using Microsoft.AspNetCore.Mvc;

namespace SuperBowlWeb.Controllers
{
    public class ErrorController : BaseApiController
    {
        [HttpGet]
        [Route("/api/[controller]/badrequest")]
        public async Task<IActionResult> badrequest()
        {
            return BadRequest(string.Empty);
        }
        [HttpGet]
        [Route("/api/[controller]/notfound")]
        public async Task<IActionResult> notfound()
        {
            return BadRequest(string.Empty);
        }
        [HttpGet]
        [Route("/api/[controller]/servererror")]
        public async Task<IActionResult> serverError()
        {
            throw new Exception("Erreur cote serveur");
        }
        [HttpGet]
        [Route("/api/[controller]/unauthorize")]
        public async Task<IActionResult> unauthorize()
        {
            return Unauthorized("Not authorized");
        }
    }
}
