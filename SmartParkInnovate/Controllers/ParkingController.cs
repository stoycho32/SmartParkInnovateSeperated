using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts;

namespace SmartParkInnovate.Controllers
{
    [Authorize]
    public class ParkingController : Controller
    {
        private readonly IParkingService parkingService;

        public ParkingController(IParkingService parkingService)
        {
            this.parkingService = parkingService;
        }


        public async Task<IActionResult> ParkingSpots()
        {
            if (User.Identity.IsAuthenticated)
            {
                var parkingSpots = await this.parkingService.All();
                return View(nameof(ParkingSpots));
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
