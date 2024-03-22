using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.VehicleModel;
using System.Security.Claims;

namespace SmartParkInnovate.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }


        [HttpGet]
        public  IActionResult Add()
        {
            VehicleFormModel formModel = new VehicleFormModel();

            return View(formModel);
        }


        [HttpPost]
        public async Task<IActionResult> Add(VehicleFormModel formModel)
        {
            string userId = User.Id();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await this.vehicleService.Add(userId, formModel);

            return RedirectToAction(nameof(Vehicles));
        }

        [HttpGet]
        public async Task<IActionResult> Vehicles()
        {
            var vehicles = await this.vehicleService.All();

            return View(vehicles);
        }



    }
}
