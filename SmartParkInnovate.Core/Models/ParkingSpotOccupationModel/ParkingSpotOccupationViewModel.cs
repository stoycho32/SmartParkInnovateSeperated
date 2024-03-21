using SmartParkInnovate.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.ParkingSpotOccupationsViewModel
{
    public class ParkingSpotOccupationViewModel
    {
        [Required]
        public int VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; }

        [Required]
        public DateTime EnterDateTime { get; init; }


        public DateTime? ExitDateTime { get; set; }
    }
}
