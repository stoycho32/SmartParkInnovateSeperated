using SmartParkInnovate.Core.Models.CommentModel;
using SmartParkInnovate.Core.Models.PostModel;

namespace SmartParkInnovate.Core.Contracts
{
    public interface IPostService
    {
        public Task<List<PostViewModel>> All();

        public Task Add(string userId, PostFormModel model);

        public Task<PostDetailModel> Details(string userId, int postId);

        public Task LikePost(int postId, string userId);
        public Task Comment(int postId, string userId, CommentFormModel comment);

        //public Task Edit(int postId, PostFormModel model);
    }
}
