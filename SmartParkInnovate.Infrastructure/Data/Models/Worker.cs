using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class Worker : IdentityUser
    {
        public Worker()
        {
            this.Vehicles = new List<Vehicle>();
        }


        [InverseProperty(nameof(Worker))]
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
