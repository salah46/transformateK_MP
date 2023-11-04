using Microsoft.AspNetCore.Mvc;

namespace transformatek_MP.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok();
        }
    }
}