using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.CommentModel;
using SmartParkInnovate.Core.Models.LikeModel;
using SmartParkInnovate.Core.Models.PostModel;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;

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
            Worker? worker = await this.repository.GetByIdAsync<Worker>(userId);

            if (worker == null)
            {
                throw new ArgumentException(string.Format(WorkerErrorMessages.InvalidWorkerErrorMessage));
            }

            Post post = new Post()
            {
                PostBody = model.PostBody,
                WorkerId = worker.Id,
                Worker = worker
            };

            await this.repository.AddAsync(post);
            await this.repository.SaveChangesAsync();
        }

        public async Task<PostDetailModel> Details(string userId, int postId)
        {
            PostDetailModel? postModel = await this.repository.AllAsReadOnly<Post>()
                .Include(c => c.Worker)
                .Include(c => c.Likes)
                .Include(c => c.Comments)
                .Where(c => c.Id == postId)
                .Select(c => new PostDetailModel()
                {
                    CurrentUser = userId,
                    PostDetailViewModel = new PostDetailViewModel()
                    {
                        Id = c.Id,
                        WorkerId = c.WorkerId,
                        WorkerUsername = c.Worker.UserName,
                        PostBody = c.PostBody,
                        PostDate = c.PostDate,
                        PostComments = c.Comments.Select(c => new CommentViewModel()
                        {
                            WorkerUsername = c.Worker.UserName,
                            CommentBody = c.CommentBody,
                            CommentDate = c.CommentDate,
                        }).ToList(),
                        PostLikes = c.Likes.Select(c => new LikeViewModel()
                        {
                            WorkerUsername = c.Worker.UserName
                        }).ToList()
                    }
                })
                .FirstOrDefaultAsync();

            if (postModel == null)
            {
                throw new ArgumentException(string.Format(PostErrorMessages.InvalidPostErrorMessage));
            }

            return postModel;
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
