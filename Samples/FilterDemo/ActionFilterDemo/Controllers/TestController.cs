using Microsoft.AspNetCore.Mvc;

namespace ActionFilterDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
