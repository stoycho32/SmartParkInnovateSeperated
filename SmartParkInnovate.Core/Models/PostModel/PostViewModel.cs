using System.ComponentModel.DataAnnotations;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.PostDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.PostErrorMessages;

namespace SmartParkInnovate.Core.Models.PostModel
{
    public class PostViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string WorkerUserName { get; set; } = null!;

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
    }
}
