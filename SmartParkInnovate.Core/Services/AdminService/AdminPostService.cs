using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.AdminModels.AdminCommentModel;
using SmartParkInnovate.Core.Models.AdminModels.AdminPostModels;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;
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

        public Task DeleteComment(string workerId, int postId, DateTime commentDate)
        {
            throw new NotImplementedException();
        }

        public Task ReturnComment(string workerId, int postId, DateTime commentDate)
        {
            throw new NotImplementedException();
        }
    }
}
