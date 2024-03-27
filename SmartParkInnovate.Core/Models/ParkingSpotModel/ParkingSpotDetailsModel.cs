using SmartParkInnovate.Core.Models.ParkingSpot;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.ParkingSpotModel
{
    public class ParkingSpotDetailsModel
    {
        public string? CurrentUserId { get; set; }

        [Required]
        public ParkingSpotDetailsViewModel ParkingSpotDetailsViewModel { get; set; } = null!;
    }
}
