using SmartParkInnovate.Core.Models.VehicleModel;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.ParkingSpotOccupationModel
{
    public class ParkingSpotOccupationViewModel
    {
        [Required]
        public DateTime EnterDateTime { get; set; }

        public DateTime? ExitDateTime { get; set; }
    }
}
