using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.AdminModels.AdminParkingModels
{
    public class ParkingOccupationsAdminViewModel
    {
        [Required]
        public int ParkingSpotId { get; set; }

        [Required]
        [LicensePlateFormat]
        public string VehicleLicensePlate { get; set; } = null!;

        [Required]
        public string VehicleOwnerEmail { get; set; } = null!;

        [Required]
        public string VehicleOwnerFullName { get; set; } = null!;

        [Required]
        public DateTime EnterDateTime { get; set; }

        public DateTime? ExitDateTime { get; set; }
    }
}
