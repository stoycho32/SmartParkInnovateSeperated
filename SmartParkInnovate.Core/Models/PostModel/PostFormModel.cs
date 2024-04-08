using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.PostDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.PostErrorMessages;

namespace SmartParkInnovate.Core.Models.PostModel
{
    public class PostFormModel
    {
        [Required]
        [PostFormat]
        [StringLength(PostBodyMaxValue,
            MinimumLength = PostBodyMinValue,
            ErrorMessage = PostBodyErrorMessage)]
        public string PostBody { get; set; } = null!;
    }
}
