﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class Post
    {
        public Post()
        {
            this.PostDate = DateTime.Now;
            this.Likes = new List<PostLike>();
            this.Comments = new List<Comment>();
        }


        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Post body cannot be empty.")]
        public string PostBody { get; set; } = null!;


        [Required]
        public DateTime PostDate { get; init; }

        [Required]
        public string OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Worker Owner { get; set; }


        [InverseProperty(nameof(Post))]
        public ICollection<PostLike> Likes { get; set; }


        [InverseProperty(nameof(Post))]
        public ICollection<Comment> Comments { get; set; }
    }
}
