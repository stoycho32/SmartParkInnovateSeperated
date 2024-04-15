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
            IEnumerable<ParkingSpotViewModel> parkingSpots = await this.parkingService.ParkingSpots();
            return View(parkingSpots);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string userId = User.Id();
                ParkingSpotDetailsModel parkingSpot = await this.parkingService.Details(id, userId);
                return View(parkingSpot);
            }
            catch (ArgumentException argException)
            {
                return this.HandleErrorMessage(argException.Message);
            }
            catch(InvalidOperationException ioe)
            {
                return this.HandleErrorMessage(ioe.Message);
            }
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

        private IActionResult HandleErrorMessage(string message)
        {
            return View("CustomError", message);
        }
    }
}
