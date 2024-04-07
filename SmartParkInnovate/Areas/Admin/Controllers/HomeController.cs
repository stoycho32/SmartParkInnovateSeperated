using Microsoft.AspNetCore.Mvc;

namespace SmartParkInnovate.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
