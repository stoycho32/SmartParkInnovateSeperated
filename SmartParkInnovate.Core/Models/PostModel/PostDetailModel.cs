using SmartParkInnovate.Core.Models.CommentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.PostModel
{
    public class PostDetailModel
    {
        [Required]
        public string CurrentUser { get; set; } = null!;

        public PostDetailViewModel PostDetailViewModel { get; set; } = null!;

        public CommentFormModel CommentFormModel { get; set; } = new CommentFormModel();
    }
}
