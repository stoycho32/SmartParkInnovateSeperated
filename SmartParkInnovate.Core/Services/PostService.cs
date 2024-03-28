using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.PostModel;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;

namespace SmartParkInnovate.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository repository;

        public PostService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<PostViewModel>> All()
        {
            List<PostViewModel> posts = await this.repository.All<Post>()
                .Select(c => new PostViewModel()
                {
                    Id = c.Id,
                    WorkerUserName = c.Worker.UserName,
                    PostBody = c.PostBody,
                    PostDate = c.PostDate,
                    LikesCount = c.Likes.Count(),
                    CommentsCount = c.Comments.Count()
                })
                .ToListAsync();

            return posts;
        }

        public async Task Add(string userId, PostFormModel model)
        {

            throw new NotImplementedException();
        }

        public Task Details(int postId)
        {
            throw new NotImplementedException();
        }
        public Task LikePost(int postId)
        {
            throw new NotImplementedException();
        }
        public Task Comment(int postId)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int postId)
        {
            throw new NotImplementedException();
        }
        public Task Edit(int postId, PostFormModel model)
        {
            throw new NotImplementedException();
        }
    }
}
