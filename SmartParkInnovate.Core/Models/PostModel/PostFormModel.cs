using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;

namespace SmartParkInnovate.Core.Models.PostModel
{
    public class PostFormModel
    {
        [Required]
        [PostFormat]
        [StringLength(PostDataConstants.PostBodyMaxValue,
            MinimumLength = PostDataConstants.PostBodyMinValue,
            ErrorMessage = PostErrorMessages.PostBodyErrorMessage)]
        public string PostBody { get; set; } = null!;
    }
}
