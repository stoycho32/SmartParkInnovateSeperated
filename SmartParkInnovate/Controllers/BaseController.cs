using Microsoft.AspNetCore.Mvc;

namespace SmartParkInnovate.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
