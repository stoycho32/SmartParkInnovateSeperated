using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class PostLike
    {
        [Key]
        public int Id { get; set; }

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
