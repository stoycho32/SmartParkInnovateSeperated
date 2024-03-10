using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class ParkingSpotOccupation
    {
        public ParkingSpotOccupation()
        {
            this.EnterDate = DateTime.Now;
            this.ExitDate = null;
        }


        [Key]
        public int Id { get; set; }


        [Required]
        public int ParkingSpotId { get; set; }

        [ForeignKey(nameof(ParkingSpotId))]
        public ParkingSpot ParkingSpot { get; set; }


        [Required]
        public int VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; }

        [Required]
        public DateTime EnterDate { get; init; }

        [Required]
        public DateTime? ExitDate { get; set; }
    }
}
