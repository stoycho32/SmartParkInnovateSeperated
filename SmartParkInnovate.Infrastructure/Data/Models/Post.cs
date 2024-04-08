using SmartParkInnovate.Infrastructure.Contracts;
using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.PostDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.PostErrorMessages;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class Post : IDeletable
    {
        public Post()
        {
            this.PostDate = DateTime.Now;
            this.IsDeleted = false;
            this.Likes = new List<PostLike>();
            this.Comments = new List<PostComment>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [PostFormat]
        [StringLength(PostBodyMaxValue,
            MinimumLength = PostBodyMinValue,
            ErrorMessage = PostBodyErrorMessage)]
        public string PostBody { get; set; } = null!;


        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        public string WorkerId { get; set; }

        [ForeignKey(nameof(WorkerId))]
        public Worker Worker { get; set; }


        [InverseProperty(nameof(Post))]
        public ICollection<PostLike> Likes { get; set; }


        [InverseProperty(nameof(Post))]
        public ICollection<PostComment> Comments { get; set; }
    }
}
