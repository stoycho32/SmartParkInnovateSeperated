using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.CommentModel;
using SmartParkInnovate.Core.Models.LikeModel;
using SmartParkInnovate.Core.Models.PostModel;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.PostErrorMessages;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.WorkerErrorMessages;

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
            List<PostViewModel> posts = await this.repository.AllAsReadOnly<Post>()
                .AsSplitQuery()
                .Where(c => c.IsDeleted == false)
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
                throw new ArgumentException(string.Format(InvalidWorkerErrorMessage));
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
                .AsSplitQuery()
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
                        LikesCount = c.Likes.Count(),
                        CommentsCount = c.Comments.Count(),
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
                throw new ArgumentException(string.Format(InvalidPostErrorMessage));
            }

            return postModel;
        }

        public async Task LikePost(int postId, string userId)
        {
            Post? post = await this.repository.All<Post>()
                .Include(c => c.Likes)
                .Where(c => c.Id == postId)
                .FirstOrDefaultAsync();

            Worker? worker = await this.repository.GetByIdAsync<Worker>(userId);

            if (post == null)
            {
                throw new ArgumentException(string.Format(InvalidPostErrorMessage));
            }

            if (worker == null)
            {
                throw new ArgumentException(string.Format(InvalidWorkerErrorMessage));
            }

            PostLike? existingLike = post.Likes.FirstOrDefault(c => c.WorkerId == userId && c.PostId == post.Id);

            if (existingLike != null)
            {
                post.Likes.Remove(existingLike);
                await this.repository.SaveChangesAsync();
            }
            else
            {
                PostLike like = new PostLike()
                {
                    WorkerId = worker.Id,
                    Worker = worker,
                    PostId = post.Id,
                    Post = post
                };

                post.Likes.Add(like);
                await this.repository.SaveChangesAsync();
            }
        }

        public async Task Comment(int postId, string userId, CommentFormModel comment)
        {
            Post? post = await this.repository.GetByIdAsync<Post>(postId);

            Worker? worker = await this.repository.GetByIdAsync<Worker>(userId);

            if (post == null)
            {
                throw new ArgumentException(string.Format(InvalidPostErrorMessage));
            }

            if (worker == null)
            {
                throw new ArgumentException(string.Format(InvalidWorkerErrorMessage));
            }

            PostComment postComment = new PostComment()
            {
                CommentBody = comment.CommentBody,
                WorkerId = worker.Id,
                Worker = worker,
                PostId = post.Id,
                Post = post
            };

            post.Comments.Add(postComment);
            await this.repository.SaveChangesAsync();
        }

        public async Task Edit(int postId, PostFormModel model)
        {
            Post? postToEdit = await this.repository.GetByIdAsync<Post>(postId);

            if (postToEdit == null)
            {
                throw new ArgumentException(string.Format(InvalidPostErrorMessage));
            }

            postToEdit.PostBody = model.PostBody;
            await this.repository.SaveChangesAsync();
        }

        public async Task<PostFormModel> GetPostById(int id)
        {
            Post? post = await this.repository.GetByIdAsync<Post>(id);

            if (post == null)
            {
                throw new ArgumentException(string.Format(InvalidPostErrorMessage));
            }

            if (post.IsDeleted == true)
            {
                throw new ArgumentException(string.Format(PostIsDeletedErrorMessage));
            }

            return new PostFormModel()
            {
                PostBody = post.PostBody
            };
        }
    }
}
