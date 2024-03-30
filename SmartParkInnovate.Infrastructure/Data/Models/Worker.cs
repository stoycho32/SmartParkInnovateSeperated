using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

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
