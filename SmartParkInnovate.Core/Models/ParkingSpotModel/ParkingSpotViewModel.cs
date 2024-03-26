using SmartParkInnovate.Core.Models.VehicleModel;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.ParkingSpot
{
    public class ParkingSpotViewModel
    {
        public int Id { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [Required]
        public bool IsOccupied { get; set; }
    }
}
