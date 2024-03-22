using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.ParkingSpotOccupationsViewModel
{
    public class ParkingSpotOccupationViewModel
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public string VehicleLicensePlate { get; set; }

        [Required]
        public string VehicleOwner { get; set; }

        [Required]
        public DateTime EnterDateTime { get; init; }

        public DateTime? ExitDateTime { get; set; }
    }
}
