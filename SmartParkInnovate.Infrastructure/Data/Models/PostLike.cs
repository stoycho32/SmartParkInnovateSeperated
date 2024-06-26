﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class PostLike
    {
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
