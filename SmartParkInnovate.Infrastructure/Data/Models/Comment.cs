using SmartParkInnovate.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(DataConstants.CommentBodyMaxValue,
            MinimumLength = DataConstants.CommentBodyMinValue,
            ErrorMessage = ErrorMessages.CommentBodyErrorMessage)]
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
