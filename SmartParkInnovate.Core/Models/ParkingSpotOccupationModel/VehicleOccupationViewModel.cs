using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.ParkingSpotOccupationModel
{
    public class VehicleOccupationViewModel
    {
        [Required]
        public int ParkingSpotId { get; set; }

        [Required]
        public DateTime EnterDateTime { get; set; }

        public DateTime? ExitDateTime { get; set; }
    }
}
