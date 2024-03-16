using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class Comment
    {
        public Comment()
        {
            this.CommentDate = DateTime.Now;
        }


        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(CommentDataConstants.CommentBodyMaxValue,
            MinimumLength = CommentDataConstants.CommentBodyMinValue,
            ErrorMessage = CommentErrorMessages.CommentBodyErrorMessage)]
        public string CommentBody { get; set; } = null!;


        [Required]
        public DateTime CommentDate { get; init; }


        [Required]
        public string WorkerId { get; set; }

        [ForeignKey(nameof(WorkerId))]
        public Worker Worker { get; set; }


        [Required]
        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
}
