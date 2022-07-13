using Microsoft.AspNetCore.Mvc;

namespace ActionFilterDemo.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
