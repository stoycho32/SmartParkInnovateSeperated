using SmartParkInnovate.Core.Models.ParkingSpotOccupationsViewModel;
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

        public ICollection<ParkingSpotOccupationViewModel> ParkingSpotOccupations { get; set; } = new List<ParkingSpotOccupationViewModel>();
    }
}
