using Microsoft.AspNetCore.Mvc;

namespace SmartParkInnovate.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
