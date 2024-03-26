using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;

namespace SmartParkInnovate.Core.Models.VehicleModel
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(VehicleDataConstants.VehicleMakeMaxLength,
            MinimumLength = VehicleDataConstants.VehicleMakeMinLength)]
        public string Make { get; set; } = null!;


        [Required]
        [StringLength(VehicleDataConstants.VehicleModelMaxLength,
            MinimumLength = VehicleDataConstants.VehicleModelMinLength,
            ErrorMessage = VehicleErrorMessages.VehicleModelLengthErrorMessage)]
        public string Model { get; set; } = null!;


        [Required]
        [LicensePlateFormat]
        public string LicensePlate { get; set; } = null!;

        [Required]
        public string WorkerUserName { get; set; } = null!;
    }
}
