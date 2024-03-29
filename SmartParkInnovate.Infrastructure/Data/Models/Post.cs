using SmartParkInnovate.Infrastructure.Contracts;
using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class Post : IDeletable
    {
        public Post()
        {
            this.PostDate = DateTime.Now;
            this.Likes = new List<PostLike>();
            this.Comments = new List<Comment>();
            this.IsDeleted = false;
            this.DeletedOn = null;
        }


        [Key]
        public int Id { get; set; }


        [Required]
        [PostFormat]
        [StringLength(PostDataConstants.PostBodyMaxValue,
            MinimumLength = PostDataConstants.PostBodyMinValue,
            ErrorMessage = PostErrorMessages.PostBodyErrorMessage)]
        public string PostBody { get; set; } = null!;


        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public string WorkerId { get; set; }

        [ForeignKey(nameof(WorkerId))]
        public Worker Worker { get; set; }


        [InverseProperty(nameof(Post))]
        public ICollection<PostLike> Likes { get; set; }


        [InverseProperty(nameof(Post))]
        public ICollection<Comment> Comments { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
