﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class PostComment
    {
        public PostComment()
        {
            this.CommentDate = DateTime.Now;
        }

        [Required]
        [StringLength(CommentDataConstants.CommentBodyMaxValue,
            MinimumLength = CommentDataConstants.CommentBodyMinValue,
            ErrorMessage = CommentErrorMessages.CommentBodyErrorMessage)]
        public string CommentBody { get; set; } = null!;


        [Required]
        public DateTime CommentDate { get; set; }


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