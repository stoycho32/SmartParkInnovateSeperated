using SmartParkInnovate.Infrastructure.Data.Attributes;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.VehicleDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.VehicleErrorMessages;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.AdminModels.AdminVehicleModels
{
    public class AdminVehicleViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(VehicleMakeMaxLength,
            MinimumLength = VehicleMakeMinLength)]
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
    }
}
