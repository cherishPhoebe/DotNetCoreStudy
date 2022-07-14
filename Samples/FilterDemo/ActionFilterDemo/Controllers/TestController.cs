using ActionFilterDemo.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilterDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [NoLogAttribute]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [NoLogAttribute]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
