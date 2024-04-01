using System.ComponentModel.DataAnnotations;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;

namespace SmartParkInnovate.Core.Models.CommentModel
{
    public class CommentFormModel
    {
        [Required]
        [StringLength(CommentDataConstants.CommentBodyMaxValue,
            MinimumLength = CommentDataConstants.CommentBodyMinValue,
            ErrorMessage = CommentErrorMessages.CommentBodyErrorMessage)]
        public string CommentBody { get; set; } = null!;
    }
}
