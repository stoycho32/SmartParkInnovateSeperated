using SmartParkInnovate.Infrastructure.Data.Attributes;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.VehicleDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.VehicleErrorMessages;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.AdminModels.AdminVehicleModels
{
    public class AdminVehicleDetailsModel
    {
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
        [EmailAddress]
        public string OwnerEmail { get; set; } = null!;

        [Required]
        public string OwnerFullName { get; set; } = null!;

        [Required]
        public int OccupationsCount { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
