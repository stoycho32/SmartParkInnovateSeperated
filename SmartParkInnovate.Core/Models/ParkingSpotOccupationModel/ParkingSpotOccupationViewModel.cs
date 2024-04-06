using SmartParkInnovate.Core.Models.VehicleModel;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.ParkingSpotOccupationsViewModel
{
    public class ParkingSpotOccupationViewModel
    {
        [Required]
        public int? VehicleId { get; set; }

        [Required]
        public string OccupationVehicleLicensePlate { get; set; } = null!;

        [Required]
        public string OccupationVehicleWorkerId { get; set; } = null!;

        [Required]
        public string OccupationVehicleWorkerUserName { get; set; } = null!;

        [Required]
        public DateTime EnterDateTime { get; set; }

        public DateTime? ExitDateTime { get; set; }
    }
}
