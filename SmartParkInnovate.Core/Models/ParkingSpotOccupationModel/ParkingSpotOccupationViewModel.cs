using SmartParkInnovate.Core.Models.VehicleModel;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.ParkingSpotOccupationsViewModel
{
    public class ParkingSpotOccupationViewModel
    {
        [Required]
        public int? VehicleId { get; set; }

        public string OccupationVehicleLicensePlate { get; set; }

        public string OccupationVehicleWorkerUserName { get; set; }

        [Required]
        public DateTime EnterDateTime { get; init; }

        public DateTime? ExitDateTime { get; set; }
    }
}
