using SmartParkInnovate.Core.Models.AdminModels.AdminCommentModel;
using SmartParkInnovate.Core.Models.AdminModels.AdminPostModels;

namespace SmartParkInnovate.Core.Contracts.AdminServiceContracts
{
    public interface IAdminPostService
    {
        public Task<IEnumerable<AdminPostViewModel>> Posts();

        public Task DeletePost(int id);

        public Task ReturnPost(int id);

        public Task<IEnumerable<AdminCommentViewModel>> Comments(int id);

        public Task DeleteComment(string workerId, int postId, Guid commentGuid);

        public Task ReturnComment(string workerId, int postId, Guid commentGuid);
    }
}
