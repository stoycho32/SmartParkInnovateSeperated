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
                List<Core.Models.ParkingSpot.ParkingSpotViewModel> parkingSpots = await this.parkingService.All();
                return View(parkingSpots);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
