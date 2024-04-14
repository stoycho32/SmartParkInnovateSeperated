using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.AdminModels.AdminCommentModel;
using SmartParkInnovate.Core.Models.AdminModels.AdminPostModels;

namespace SmartParkInnovate.Areas.Admin.Controllers
{
    public class PostController : AdminBaseController
    {
        private readonly IAdminPostService adminPostService;

        public PostController(IAdminPostService adminPostService)
        {
            this.adminPostService = adminPostService;
        }

        [HttpGet]
        public async Task<IActionResult> Posts()
        {
            IEnumerable<AdminPostViewModel> posts = await this.adminPostService.Posts();

            return View(posts);
        }

        [HttpGet]
        public async Task<IActionResult> DeletePost(int id)
        {
            await this.adminPostService.DeletePost(id);

            return RedirectToAction(nameof(Posts));
        }

        [HttpGet]
        public async Task<IActionResult> ReturnPost(int id)
        {
            await this.adminPostService.ReturnPost(id);

            return RedirectToAction(nameof(Posts));
        }

        [HttpGet]
        public async Task<IActionResult> PostComments()
        {
            IEnumerable<AdminCommentViewModel> comments = await this.adminPostService.Comments();

            return View(comments);
        }
    }
}
