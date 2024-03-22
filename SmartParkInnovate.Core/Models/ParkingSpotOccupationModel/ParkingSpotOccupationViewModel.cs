using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.ParkingSpotOccupationsViewModel
{
    public class ParkingSpotOccupationViewModel
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public string VehicleMake { get; set; }

        [Required]
        public string VehicleModel { get; set; }

        [Required]
        public string VehicleLicensePlate { get; set; }

        [Required]
        public string WorkerUserName { get; set; }

        [Required]
        public DateTime EnterDateTime { get; init; }

        public DateTime? ExitDateTime { get; set; }
    }
}
