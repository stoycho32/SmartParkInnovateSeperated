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
            try
            {
                await this.adminPostService.DeletePost(id);
                return RedirectToAction(nameof(Posts));
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
        public async Task<IActionResult> ReturnPost(int postId)
        {
            try
            {
                await this.adminPostService.ReturnPost(postId);
                return RedirectToAction(nameof(Posts));
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
        public async Task<IActionResult> PostComments(int postId)
        {
            IEnumerable<AdminCommentViewModel> comments = await this.adminPostService.Comments(postId);

            return View(comments);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComment(string workerId, int postId, Guid commentGuid)
        {
            try
            {
                await this.adminPostService.DeleteComment(workerId, postId, commentGuid);
                return RedirectToAction(nameof(PostComments), new { postId });
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
        public async Task<IActionResult> ReturnComment(string workerId, int postId, Guid commentGuid)
        {
            try
            {
                await this.adminPostService.ReturnComment(workerId, postId, commentGuid);
                return RedirectToAction(nameof(PostComments), new { postId });
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