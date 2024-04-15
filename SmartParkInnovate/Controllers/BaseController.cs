using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartParkInnovate.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected IActionResult HandleErrorMessage(string message)
        {
            return View("CustomError", message);
        }
    }
}
