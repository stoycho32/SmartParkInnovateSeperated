using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.AdminModels.AdminParkingModels;

namespace SmartParkInnovate.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly IAdminParkingService adminParkingService;

        public HomeController(IAdminParkingService adminParkingService)
        {
            this.adminParkingService = adminParkingService;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            GeneralAdminInformationModel adminInfoModel = this.adminParkingService.GetAdminReport();

            return View(adminInfoModel);
        }
    }
}
