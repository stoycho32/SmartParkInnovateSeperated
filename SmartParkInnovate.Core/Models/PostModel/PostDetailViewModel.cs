using SmartParkInnovate.Core.Models.CommentModel;
using SmartParkInnovate.Core.Models.LikeModel;
using System.ComponentModel.DataAnnotations;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.PostDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.PostErrorMessages;

namespace SmartParkInnovate.Core.Models.PostModel
{
    public class PostDetailViewModel
    {
        public int Id { get; set; }

        [Required]
        public string WorkerId { get; set; } = null!;

        [Required]
        public string WorkerUsername { get; set; } = null!;


        [Required]
        [StringLength(PostBodyMaxValue,
            MinimumLength = PostBodyMinValue,
            ErrorMessage = PostBodyErrorMessage)]
        public string PostBody { get; set; } = null!;


        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public int LikesCount { get; set; }

        [Required]
        public int CommentsCount { get; set; }

        [Required]
        public IEnumerable<CommentViewModel> PostComments { get; set; } = new List<CommentViewModel>();

        [Required]
        public IEnumerable<LikeViewModel> PostLikes { get; set; } = new List<LikeViewModel>();
    }
}
