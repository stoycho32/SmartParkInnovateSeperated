using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpot;

namespace SmartParkInnovate.Controllers
{
    public class ParkingController : BaseController
    {
        private readonly IParkingService parkingService;

        public ParkingController(IParkingService parkingService)
        {
            this.parkingService = parkingService;
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ParkingSpotDetailsViewModel parkingSpot = await this.parkingService.Details(id);

            return View(parkingSpot);
        }
    }
}
