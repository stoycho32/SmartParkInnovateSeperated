using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts;
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
            List<PostViewModel> posts = await this.postService.All();

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
            string userId = User.Id();

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await this.postService.Add(userId, model);

            return RedirectToAction(nameof(Posts));
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
            string userId = User.Id();

            await this.postService.LikePost(id, userId);

            return RedirectToAction(nameof(Details), new {id});
        }
    }
}
