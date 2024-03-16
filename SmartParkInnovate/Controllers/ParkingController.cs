using Microsoft.AspNetCore.Mvc;

namespace SmartParkInnovate.Controllers
{
    public class ParkingController : Controller
    {
        public IActionResult All()
        {
            return View(nameof(All));
        }
    }
}
