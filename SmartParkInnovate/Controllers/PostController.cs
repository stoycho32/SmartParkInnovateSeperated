using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.CommentModel;
using SmartParkInnovate.Core.Models.PostModel;
using System.Security.Claims;

namespace SmartParkInnovate.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Posts()
        {
            IEnumerable<PostViewModel> posts = await this.postService.All();

            return View(posts);
        }

        [HttpGet]
        public IActionResult PublishPost()
        {
            PostFormModel model = new PostFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PublishPost(PostFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                string userId = User.Id();
                await this.postService.Add(userId, model);

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
        public async Task<IActionResult> Details(int id)
        {
            string userId = User.Id();
            PostDetailModel model = await this.postService.Details(userId, id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LikePost(int id)
        {
            try
            {
                string userId = User.Id();
                await this.postService.LikePost(id, userId);

                return RedirectToAction(nameof(Details), new { id });
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
        public IActionResult CommentPost(int id)
        {
            CommentFormModel model = new CommentFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CommentPost(int id, CommentFormModel comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                string userId = User.Id();
                await this.postService.Comment(id, userId, comment);

                return RedirectToAction(nameof(Details), new { id });
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
        public async Task<IActionResult> EditPost(int id)
        {
            PostFormModel model = await this.postService.GetPostById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(int id, PostFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                string currentUser = User.Id();
                await this.postService.Edit(id, currentUser, model);

                return RedirectToAction(nameof(Details), new { id });
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