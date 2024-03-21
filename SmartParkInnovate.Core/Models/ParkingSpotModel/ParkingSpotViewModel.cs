using SmartParkInnovate.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
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


        public int? OccupationVehicleId { get; set; }

        public Vehicle? OccupationVehicle { get; set; }
    }
}
