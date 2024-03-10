using SmartParkInnovate.Infrastructure.Data.Attributes;
using SmartParkInnovate.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(DataConstants.VehicleMakeMaxLength,
            MinimumLength = DataConstants.VehicleMakeMinLength,
            ErrorMessage = ErrorMessages.VehicleMakeLengthErrorMessage)]
        public string Make { get; set; } = null!;


        [Required]
        [StringLength(DataConstants.VehicleModelMaxLength,
            MinimumLength = DataConstants.VehicleModelMinLength,
            ErrorMessage = ErrorMessages.VehicleModelLengthErrorMessage)]
        public string Model { get; set; } = null!;


        [Required]
        [LicensePlateFormat]
        public string LicensePlate { get; set; } = null!;


        [Required]
        public string OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Worker Owner { get; set; }
    }
}
