using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Car make must be between 2 and 50 characters long.")]
        public string Make { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Car model name must be between 3 and 50 characters long.")]
        public string Model { get; set; }


        [Required]
        [LicensePlateFormat]
        public string LicensePlate { get; set; }


        [Required]
        public int OwnerId { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public Worker Owner { get; set; }
    }
}
