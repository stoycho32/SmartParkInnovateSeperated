using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class ParkingSpot
    {
        public ParkingSpot()
        {
            this.IsReserved = false;
            this.IsOccupied = false;
        }

        [Key]
        public int Id { get; set; }


        [Required]
        public bool IsReserved { get; set; }
        [Required]
        public bool IsOccupied { get; set; }


        public int? ReservationVehicleId { get; set; }

        [ForeignKey(nameof(ReservationVehicleId))]
        public Vehicle? ReservationVehicle { get; set; }


        public int? OccupationVehicleId { get; set; }

        [ForeignKey(nameof(OccupationVehicleId))]
        public Vehicle? OccupationVehicle { get; set; }
    }
}
