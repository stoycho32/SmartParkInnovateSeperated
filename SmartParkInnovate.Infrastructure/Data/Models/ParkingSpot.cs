using SmartParkInnovate.Infrastructure.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class ParkingSpot
    {
        public ParkingSpot()
        {
            this.IsOccupied = false;
            this.IsEnabled = true;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [Required]
        public bool IsOccupied { get; set; }


        public int? OccupationVehicleId { get; set; }

        [ForeignKey(nameof(OccupationVehicleId))]
        public Vehicle? OccupationVehicle { get; set; }
    }
}
