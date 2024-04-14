using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpotModel;
using SmartParkInnovate.Models;
using System.Diagnostics;

namespace SmartParkInnovate.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IParkingService parkingService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IParkingService parkingService, ILogger<HomeController> logger)
        {
            this.parkingService = parkingService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            GeneralParkingInformationModel model = this.parkingService.GeneralParkingSpotInformation();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}