using Microsoft.AspNetCore.Mvc;

namespace Tweetbook.Controllers
{
    public class RubenController : Controller
    {
        [HttpGet("api/user")]
        public IActionResult Get()
        {
            return Ok(new {name = "Ruben"});
        }
    }
}