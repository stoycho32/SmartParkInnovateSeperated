using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.PostErrorMessages;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.PostDataConstants;

using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.AdminModels.AdminPostModels
{
    public class AdminPostViewModel
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
        public bool IsDeleted { get; set; }
    }
}
