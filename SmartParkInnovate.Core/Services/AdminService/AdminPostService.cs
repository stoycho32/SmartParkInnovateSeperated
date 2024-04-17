using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.AdminModels.AdminCommentModel;
using SmartParkInnovate.Core.Models.AdminModels.AdminPostModels;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.CommentErrorMessages;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.PostErrorMessages;

namespace SmartParkInnovate.Core.Services.AdminService
{
    public class AdminPostService : IAdminPostService
    {
        private readonly IRepository repository;

        public AdminPostService(IRepository repository)
        {
            this.repository = repository;
        }



        /// <summary>
        /// Getting all the posts (Deleted and Non Deleted)
        /// </summary>
        /// <returns>Collection of all the posts in the application</returns>
        public async Task<IEnumerable<AdminPostViewModel>> Posts()
        {
            IEnumerable<AdminPostViewModel> posts = await this.repository.AllAsReadOnly<Post>()
                .Select(c => new AdminPostViewModel() 
                {
                    Id = c.Id,
                    WorkerUserName = c.Worker.UserName,
                    PostBody = c.PostBody,
                    PostDate = c.PostDate,
                    IsDeleted = c.IsDeleted
                })
                .OrderByDescending(c => c.PostDate)
                .ToListAsync();

            return posts;
        }


        /// <summary>
        /// This allows the admin to delete a specific post
        /// </summary>
        /// <param name="id">post id</param>
        /// <exception cref="ArgumentException">If the post is invalid</exception>
        /// <exception cref="InvalidOperationException">If the post is already deleted</exception>
        public async Task DeletePost(int id)
        {
            Post? postToDelete = await this.repository.GetByIdAsync<Post>(id);

            if (postToDelete == null)
            {
                throw new ArgumentException(string.Format(InvalidPostErrorMessage));
            }

            if (postToDelete.IsDeleted == true)
            {
                throw new InvalidOperationException(string.Format(PostIsDeletedErrorMessage));
            }

            postToDelete.IsDeleted = true;
            postToDelete.DeletedOn = DateTime.Now;

           await this.repository.SaveChangesAsync();
        }


        /// <summary>
        /// This allows the admin to return a specific post
        /// </summary>
        /// <param name="id">post id</param>
        /// <exception cref="ArgumentException">If the post is invalid</exception>
        /// <exception cref="InvalidOperationException">If the post is already returned/not deleted</exception>
        public async Task ReturnPost(int id)
        {
            Post? postToDelete = await this.repository.GetByIdAsync<Post>(id);

            if (postToDelete == null)
            {
                throw new ArgumentException(string.Format(InvalidPostErrorMessage));
            }

            if (postToDelete.IsDeleted == false)
            {
                throw new InvalidOperationException(string.Format(PostIsNotDeletedErrorMessage));
            }

            postToDelete.IsDeleted = false;
            postToDelete.DeletedOn = DateTime.Now;

           await this.repository.SaveChangesAsync();
        }



        /// <summary>
        /// Viewing all the comments for the post in order to operate with them
        /// </summary>
        public async Task<IEnumerable<AdminCommentViewModel>> Comments(int id)
        {
            IEnumerable<AdminCommentViewModel> comments = await this.repository.AllAsReadOnly<PostComment>()
                .Where(c => c.PostId == id)
                .Select(c => new AdminCommentViewModel()
                {
                    CommentGuid = c.CommentGuid,
                    WorkerUsername = c.Worker.UserName,
                    CommentBody = c.CommentBody,
                    CommentDate = c.CommentDate,
                    IsDeleted = c.IsDeleted,
                    WorkerId = c.WorkerId,
                    PostId = c.PostId
                })
                .OrderByDescending(c => c.CommentDate)
                .ToListAsync();

            return comments;
        }


        /// <summary>
        /// returns a deleted comment
        /// </summary>
        /// <param name="workerId">using workerId as a filter</param>
        /// <param name="postId">using postId as a filter</param>
        /// <param name="commentGuid">using commentGuid as a filter</param>
        /// <exception cref="ArgumentException">if the comment is invalid</exception>
        /// <exception cref="InvalidOperationException">if the comment was not deleted before</exception>
        public async Task ReturnComment(string workerId, int postId, Guid commentGuid)
        {
            PostComment? commentToReturn = await this.repository.All<PostComment>()
                .Where(c => c.WorkerId == workerId && c.PostId == postId && c.CommentGuid == commentGuid)
                .FirstOrDefaultAsync();

            if (commentToReturn == null)
            {
                throw new ArgumentException(string.Format(InvalidCommentErrorMessage));
            }

            if (commentToReturn.IsDeleted == false && commentToReturn.DeletedOn == null)
            {
                throw new InvalidOperationException(string.Format(CommentIsNotDeletedErrorMessage));
            }

            commentToReturn.IsDeleted = false;
            commentToReturn.DeletedOn = null;

            await this.repository.SaveChangesAsync();
        }


        /// <summary>
        /// deletes a comment
        /// </summary>
        /// <param name="workerId">using workerId as a filter</param>
        /// <param name="postId">using postId as a filter</param>
        /// <param name="commentGuid">using commentGuid as a filter</param>
        /// <exception cref="ArgumentException">if the comment is invalid</exception>
        /// <exception cref="InvalidOperationException">if the comment was already deleted</exception>
        public async Task DeleteComment(string workerId, int postId, Guid commentGuid)
        {
            PostComment? commentToDelete = await this.repository.All<PostComment>()
                .Where(c => c.WorkerId == workerId && c.PostId == postId && c.CommentGuid == commentGuid)
                .FirstOrDefaultAsync();

            if (commentToDelete == null)
            {
                throw new ArgumentException(string.Format(InvalidCommentErrorMessage));
            }

            if (commentToDelete.IsDeleted == true && commentToDelete.DeletedOn != null)
            {
                throw new InvalidOperationException(string.Format(CommentIsDeletedErrorMessage));
            }

            commentToDelete.IsDeleted = true;
            commentToDelete.DeletedOn = DateTime.Now;

            await this.repository.SaveChangesAsync();
        }
    }
}
