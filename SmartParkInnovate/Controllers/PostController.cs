using Microsoft.AspNetCore.Mvc;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.PostModel;

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
    }
}
