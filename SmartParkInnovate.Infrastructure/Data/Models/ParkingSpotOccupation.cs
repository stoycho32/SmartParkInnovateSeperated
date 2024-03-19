using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class ParkingSpotOccupation
    {
        public ParkingSpotOccupation()
        {
            this.EnterDateTime = DateTime.Now;
        }

        [Required]
        public int ParkingSpotId { get; set; }

        [ForeignKey(nameof(ParkingSpotId))]
        public ParkingSpot ParkingSpot { get; set; }


        [Required]
        public int VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; }

        [Required]
        public DateTime EnterDateTime { get; init; }


        public DateTime? ExitDateTime { get; set; }
    }
}
