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
                .ToListAsync();

            return posts;
        }

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

        public async Task<IEnumerable<AdminCommentViewModel>> Comments()
        {
            IEnumerable<AdminCommentViewModel> comments = await this.repository.AllAsReadOnly<PostComment>()
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
                .ToListAsync();

            return comments;
        }

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
