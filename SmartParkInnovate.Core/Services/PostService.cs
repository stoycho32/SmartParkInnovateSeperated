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



        /// <summary>
        /// With this functionality, we can get all the posts that are not deleted
        /// </summary>
        /// <returns>Collection of non-deleted posts</returns>
        public async Task<IEnumerable<PostViewModel>> All()
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
                    CommentsCount = c.Comments.Where(c => c.IsDeleted == false).Count()
                })
                .ToListAsync();

            return posts;
        }


        /// <summary>
        /// Add Post functionality. Every user is allowed to publish a post with specific details (Usually connected with a parking spot situation)
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <param name="model">post form model in order to get the post data</param>
        /// <exception cref="ArgumentException">It throws the exception if the user is invalid</exception>
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


        /// <summary>
        /// Gets the details of the selected post
        /// </summary>
        /// <param name="userId">getting the user Id and adding it in the object in order to check if the post is his so he can edit it</param>
        /// <param name="postId">the id of the selected post</param>
        /// <returns>detail view object with more detailed post information</returns>
        /// <exception cref="ArgumentException">throws the exception if the post is invalid</exception>
        public async Task<PostDetailModel> Details(string userId, int postId)
        {
            PostDetailModel? postModel = await this.repository.AllAsReadOnly<Post>()
                .AsSplitQuery()
                .Where(c => c.Id == postId && c.IsDeleted == false)
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
                        CommentsCount = c.Comments.Where(c => c.IsDeleted == false).Count(),
                        PostComments = c.Comments.Where(c => c.IsDeleted == false).Select(c => new CommentViewModel()
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
                .OrderByDescending(c => c.PostDetailViewModel.PostDate)
                .FirstOrDefaultAsync();

            if (postModel == null)
            {
                throw new ArgumentException(string.Format(InvalidPostErrorMessage));
            }

            return postModel;
        }


        /// <summary>
        /// This fuctionality allows the users to like the selected post
        /// </summary>
        /// <param name="postId">The selected post to like</param>
        /// <param name="userId">the user that will like the post</param>
        /// <exception cref="ArgumentException">throws an exception if the worker/post are invalid and also if the post is already deleted 
        /// (not allowed to like a deleted post)</exception>
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

            if (post.IsDeleted)
            {
                throw new ArgumentException(string.Format(PostIsDeletedErrorMessage));
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



        /// <summary>
        /// This functionality allows the user to comment on a selected post
        /// </summary>
        /// <param name="postId">the id of the selected post</param>
        /// <param name="userId">the id of the user that will comment the post</param>
        /// <param name="comment">the comment details</param>
        /// <exception cref="ArgumentException">throws an exception if the worker/post are invalid and also if the post is already deleted 
        /// (not allowed to comment a deleted post)</exception>
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

            if (post.IsDeleted)
            {
                throw new ArgumentException(string.Format(PostIsDeletedErrorMessage));
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


        /// <summary>
        /// This functionality allows the user to edit a post published by him/her
        /// </summary>
        /// <param name="postId">the id of the post that will be edited</param>
        /// <param name="currentUser">the user that will be editing the post</param>
        /// <param name="model">the new post details</param>
        /// <exception cref="ArgumentException">the exception is thrown if the selected post is invalid</exception>
        /// <exception cref="InvalidOperationException">the exception is thrown if the worker is not the owner of the post or if the post is deleted</exception>
        public async Task Edit(int postId, string currentUser, PostFormModel model)
        {
            Post? postToEdit = await this.repository.All<Post>()
                .FirstOrDefaultAsync(c => c.Id == postId);

            if (postToEdit == null)
            {
                throw new ArgumentException(string.Format(InvalidPostErrorMessage));
            }

            if (postToEdit.WorkerId != currentUser)
            {
                throw new InvalidOperationException(string.Format(YouAreNotAllowedToEditPostErrorMessage));
            }

            if (postToEdit.IsDeleted)
            {
                throw new InvalidOperationException(string.Format(PostIsDeletedErrorMessage));
            }

            postToEdit.PostBody = model.PostBody;
            await this.repository.SaveChangesAsync();
        }


        /// <summary>
        /// This will get the post by Id in order to get the old post data that will be edited. 
        /// This allows the user to get the current information and in this case, he will not write it all over again (can fix typos easily this way)
        /// </summary>
        /// <param name="id">the id of the post that will be deleted</param>
        /// <exception cref="ArgumentException">If the post that is selected is invalid</exception>
        public async Task<PostFormModel> GetPostById(int id)
        {
            Post? post = await this.repository.GetByIdAsync<Post>(id);

            if (post == null)
            {
                throw new ArgumentException(string.Format(InvalidPostErrorMessage));
            }

            if (post.IsDeleted)
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
