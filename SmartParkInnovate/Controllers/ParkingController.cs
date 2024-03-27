using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpot;
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
            List<Core.Models.ParkingSpot.ParkingSpotViewModel> parkingSpots = await this.parkingService.All();
            return View(parkingSpots);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ParkingSpotDetailsViewModel parkingSpot = await this.parkingService.Details(id);

            return View(parkingSpot);
        }

        [HttpGet]
        public IActionResult UseSpot(int id)
        {
            UseSpotVehicleFormModel model = new UseSpotVehicleFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UseSpot(int id, UseSpotVehicleFormModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                string userId = User.Id();

                await this.parkingService.Use(id, userId, model);

                return RedirectToAction(nameof(ParkingSpots));
            }
            catch (ArgumentException argException)
            {
                return BadRequest();
            }
            catch(InvalidOperationException ioe)
            {
                return BadRequest();
            }
        }
    }
}
