namespace SmartParkInnovate.Core.Models.PostModel
{
    public class PostDetailModel
    {
        public string CurrentUser { get; set; }

        public PostDetailViewModel PostDetailViewModel { get; set; } = null!;

        public PostFormModel PostFormModel { get; set; } = new PostFormModel();
    }
}
