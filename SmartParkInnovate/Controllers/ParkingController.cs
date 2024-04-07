using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Core.Models.ParkingSpotModel;
using SmartParkInnovate.Core.Models.VehicleModel;
using System.Security.Claims;

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
            List<ParkingSpotViewModel> parkingSpots = await this.parkingService.All();
            return View(parkingSpots);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            string userId = User.Id();
            ParkingSpotDetailsModel parkingSpot = await this.parkingService.Details(id, userId);

            return View(parkingSpot);
        }

        [HttpGet]
        public IActionResult UseSpot(int id)
        {
            UseSpotVehicleFormModel model = new UseSpotVehicleFormModel();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UseSpot(int id, UseSpotVehicleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string userId = User.Id();

            await this.parkingService.Use(id, userId, model);

            return RedirectToAction(nameof(ParkingSpots));
        }

        [HttpPost]
        public async Task<IActionResult> ExitSpot(int id)
        {
            string userId = User.Id();

            await this.parkingService.Exit(id, userId);

            return RedirectToAction(nameof(ParkingSpots));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DisableSpot(int id)
        {
            await this.parkingService.Disable(id);

            return RedirectToAction(nameof(ParkingSpots));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EnableSpot(int id)
        {
            await this.parkingService.Enable(id);

            return RedirectToAction(nameof(ParkingSpots));
        }
    }
}
