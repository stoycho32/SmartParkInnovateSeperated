using SmartParkInnovate.Infrastructure.Contracts;
using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.VehicleDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.VehicleErrorMessages;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class Vehicle : IDeletable
    {
        public Vehicle()
        {
            this.IsDeleted = false;
            DeletedOn = null;
            this.ParkingSpotOccupations = new List<ParkingSpotOccupation>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(VehicleMakeMaxLength,
            MinimumLength = VehicleMakeMinLength, ErrorMessage = VehicleMakeLengthErrorMessage)]
        public string Make { get; set; } = null!;


        [Required]
        [StringLength(VehicleModelMaxLength,
            MinimumLength = VehicleModelMinLength,
            ErrorMessage = VehicleModelLengthErrorMessage)]
        public string Model { get; set; } = null!;


        [Required]
        [LicensePlateFormat]
        public string LicensePlate { get; set; } = null!;


        [Required]
        public string WorkerId { get; set; } = null!;

        [ForeignKey(nameof(WorkerId))]
        public Worker Worker { get; set; } = null!;


        [InverseProperty(nameof(Vehicle))]
        public ICollection<ParkingSpotOccupation> ParkingSpotOccupations { get; set; }


        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
