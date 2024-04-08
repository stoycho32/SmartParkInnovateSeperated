using SmartParkInnovate.Infrastructure.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.CommentDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.CommentErrorMessages;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class PostComment : IDeletable
    {
        public PostComment()
        {
            this.CommentDate = DateTime.Now;
        }

        [Required]
        [StringLength(CommentBodyMaxValue,
            MinimumLength = CommentBodyMinValue,
            ErrorMessage = CommentBodyErrorMessage)]
        public string CommentBody { get; set; } = null!;

        [Required]
        public DateTime CommentDate { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        [Required]
        public string WorkerId { get; set; } = null!;

        [ForeignKey(nameof(WorkerId))]
        public Worker Worker { get; set; } = null!;

        [Required]
        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; } = null!;
    }
}
