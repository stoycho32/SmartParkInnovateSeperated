using SmartParkInnovate.Core.Models.PostModel;

namespace SmartParkInnovate.Core.Contracts
{
    public interface IPostService
    {
        public Task<List<PostViewModel>> All();

        public Task Add(string userId, PostFormModel model);

        public Task<PostDetailModel> Details(string userId, int postId);
        //public Task Edit(int postId, PostFormModel model);

        //public Task Delete(int postId);

        //public Task LikePost(int postId);

        //public Task Comment(int postId);

    }
}
