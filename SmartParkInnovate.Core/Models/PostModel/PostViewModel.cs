using System.ComponentModel.DataAnnotations;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;

namespace SmartParkInnovate.Core.Models.PostModel
{
    public class PostViewModel
    {
        [Required]
        public string WorkerUserName { get; set; } = null!;

        [Required]
        [StringLength(PostDataConstants.PostBodyMaxValue,
            MinimumLength = PostDataConstants.PostBodyMaxValue,
            ErrorMessage = PostErrorMessages.PostBodyErrorMessage)]
        public string PostBody { get; set; } = null!;


        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public int LikesCount { get; set; }

        [Required]
        public int CommentsCount { get; set; }
    }
}
