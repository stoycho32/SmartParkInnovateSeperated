using SmartParkInnovate.Core.Models.ParkingSpotOccupationModel;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.ParkingSpot
{
    public class ParkingSpotDetailsViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [Required]
        public bool IsOccupied { get; set; }

        public IEnumerable<ParkingSpotOccupationViewModel> ParkingSpotOccupations { get; set; } = new List<ParkingSpotOccupationViewModel>();
    }
}
