using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SmartParkInnovate.Infrastructure.Data.Constants.AdminConstants;

namespace SmartParkInnovate.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminBaseController : Controller
    {
        protected IActionResult HandleErrorMessage(string message)
        {
            return View("AdminCustomError", message);
        }
    }
}
