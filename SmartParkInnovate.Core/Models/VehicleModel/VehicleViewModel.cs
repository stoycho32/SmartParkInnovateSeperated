using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.VehicleDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.VehicleErrorMessages;

namespace SmartParkInnovate.Core.Models.VehicleModel
{
    public class VehicleViewModel
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
    }
}
