using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts;

namespace SmartParkInnovate.Controllers
{
    public class ParkingController : Controller
    {
        private readonly IParkingService parkingService;

        public ParkingController(IParkingService parkingService)
        {
            this.parkingService = parkingService;
        }


        public async Task<IActionResult> All()
        {
            var parkingSpots = await this.parkingService.All();
            return View(nameof(All));
        }
    }
}
