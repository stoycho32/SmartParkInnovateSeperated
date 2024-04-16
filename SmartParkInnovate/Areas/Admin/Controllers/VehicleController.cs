using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.AdminModels.AdminVehicleModels;

namespace SmartParkInnovate.Areas.Admin.Controllers
{
    public class VehicleController : AdminBaseController
    {
        private readonly IAdminVehicleService adminVehicleService;

        public VehicleController(IAdminVehicleService adminVehicleService)
        {
            this.adminVehicleService = adminVehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Vehicles(string? licensePlate, string? ownerEmail, string? make, string? model)
        {
            IEnumerable<AdminVehicleViewModel> vehicles = await this.adminVehicleService.AllVehicles(licensePlate, ownerEmail, make, model);

            return View(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> VehicleDetails(int id)
        {
            AdminVehicleDetailsModel model = await this.adminVehicleService.Details(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnVehicle(int id)
        {
            try
            {
                await this.adminVehicleService.ReturnVehicle(id);
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
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            try
            {
                await this.adminVehicleService.RemoveVehicle(id);
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
    }
}