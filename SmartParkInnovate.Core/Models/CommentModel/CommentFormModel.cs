using System.ComponentModel.DataAnnotations;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.CommentDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.CommentErrorMessages;

namespace SmartParkInnovate.Core.Models.CommentModel
{
    public class CommentFormModel
    {
        [Required]
        [StringLength(CommentBodyMaxValue,
            MinimumLength = CommentBodyMinValue,
            ErrorMessage = CommentBodyErrorMessage)]
        public string CommentBody { get; set; } = null!;
    }
}
