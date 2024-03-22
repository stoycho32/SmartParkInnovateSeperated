using SmartParkInnovate.Core.Models.WorkerModel;
using SmartParkInnovate.Infrastructure.Data.Attributes;
using SmartParkInnovate.Infrastructure.Data.Constants;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;
using System.ComponentModel.DataAnnotations;
using SmartParkInnovate.Core.Models.ParkingSpotOccupationModel;

namespace SmartParkInnovate.Core.Models.VehicleModel
{
    public class VehicleDetailsViewModel
    {
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
        public string WorkerId { get; set; }

        public string WorkerUserName { get; set; }

        public ICollection<VehicleOccupationViewModel> Occupations { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
