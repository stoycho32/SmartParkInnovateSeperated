﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.WorkerDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.WorkerErrorMessages;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class Worker : IdentityUser
    {
        public Worker()
        {
            this.Vehicles = new List<Vehicle>();
            this.Posts = new List<Post>();
            this.Comments = new List<PostComment>();
            this.Likes = new List<PostLike>();
        }

        [Required]
        [StringLength(FirstNameMaxLength, ErrorMessage = FirstNameCharactersErrorMessage, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, ErrorMessage = LastNameCharactersErrorMessage, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [InverseProperty(nameof(Worker))]
        public ICollection<Vehicle> Vehicles { get; set; }


        [InverseProperty(nameof(Worker))]
        public ICollection<Post> Posts { get; set; }


        [InverseProperty(nameof(Worker))]
        public ICollection<PostComment> Comments { get; set; }


        [InverseProperty(nameof(Worker))]
        public ICollection<PostLike> Likes { get; set; }
    }
}
