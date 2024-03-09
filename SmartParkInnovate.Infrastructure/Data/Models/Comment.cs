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
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Comment cannot be empty.")]
        public string CommentBody { get; set; } = null!;


        [Required]
        public DateTime CommentDate { get; init; }


        [Required]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Worker Owner { get; set; }


        [Required]
        public int PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
}
