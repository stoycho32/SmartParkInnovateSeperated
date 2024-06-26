﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AddVehicle()
        {
            VehicleFormModel formModel = new VehicleFormModel();

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(VehicleFormModel formModel)
        {
            string userId = User.Id();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await this.vehicleService.Add(userId, formModel);
                return RedirectToAction(nameof(Vehicles));
            }
            catch (ArgumentException argException)
            {
                return this.HandleErrorMessage(argException.Message);
            }
            catch (InvalidOperationException ioe)
            {
                return this.HandleErrorMessage(ioe.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Vehicles()
        {
            string userId = User.Id();

            IEnumerable<VehicleViewModel> vehicles = await this.vehicleService.MyVehicles(userId);

            return View(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            string userId = User.Id();

            try
            {
                VehicleDetailsViewModel model = await this.vehicleService.Details(id, userId);
                return View(model);
            }
            catch (ArgumentException argException)
            {
                return this.HandleErrorMessage(argException.Message);
            }
        }
    }
}
