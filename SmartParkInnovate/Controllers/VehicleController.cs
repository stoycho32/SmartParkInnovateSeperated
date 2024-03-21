using Microsoft.AspNetCore.Mvc;

namespace SmartParkInnovate.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
