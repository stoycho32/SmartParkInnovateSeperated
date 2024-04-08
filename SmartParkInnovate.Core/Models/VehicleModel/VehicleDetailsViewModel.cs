using SmartParkInnovate.Core.Models.ParkingSpotOccupationModel;
using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using static SmartParkInnovate.Infrastructure.Data.Constants.DataConstants.VehicleDataConstants;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.VehicleErrorMessages;

namespace SmartParkInnovate.Core.Models.VehicleModel
{
    public class VehicleDetailsViewModel
    {
        [Required]
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
        public string WorkerUserName { get; set; } = null!;

        [Required]
        public string WorkerFullName { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public IEnumerable<VehicleOccupationViewModel> Occupations { get; set; } = new List<VehicleOccupationViewModel>();
    }
}
