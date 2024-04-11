using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.AdminModels.AdminParkingModels;

namespace SmartParkInnovate.Areas.Admin.Controllers
{
    public class ParkingController : AdminBaseController
    {
        private readonly IAdminParkingService adminParkingService;

        public ParkingController(IAdminParkingService adminParkingService)
        {
            this.adminParkingService = adminParkingService;
        }


        [HttpGet]
        public async Task<IActionResult> ParkingSpots()
        {
            List<ParkingSpotAdminViewModel> parkingSpots = await this.adminParkingService.ParkingSpots();

            return View(parkingSpots);
        }

        [HttpGet]
        public async Task<IActionResult> AddParkingSpot()
        {
            await this.adminParkingService.AddParkingSpot();
            return RedirectToAction(nameof(ParkingSpots));
        }

        [HttpGet]
        public async Task<IActionResult> ParkingOccupations(int? id, string? licensePlate, string? userEmail)
        {
            IEnumerable<ParkingOccupationsAdminViewModel> occupations = await this.adminParkingService.AllOccupations(id, licensePlate, userEmail);

            return View(occupations);
        }

        [HttpGet]
        public async Task<IActionResult> EnableParkingSpot(int id)
        {
            await this.adminParkingService.EnableParkingSpot(id);
            return RedirectToAction(nameof(ParkingSpots));
        }

        [HttpGet]
        public async Task<IActionResult> DisableParkingSpot(int id)
        {
            await this.adminParkingService.DisableParkingSpot(id);
            return RedirectToAction(nameof(ParkingSpots));
        }
    }
}
