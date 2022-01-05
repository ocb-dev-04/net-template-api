using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet]
        public IActionResult AllDone()
            => Ok(new { message = "You are connected", dateTime = DateTimeOffset.UtcNow.ToString() });
    }
}
