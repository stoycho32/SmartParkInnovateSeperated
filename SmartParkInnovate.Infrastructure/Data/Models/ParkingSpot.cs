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
            this.ParkingSpotOccupations = new List<ParkingSpotOccupation>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [Required]
        public bool IsOccupied { get; set; }


        [InverseProperty(nameof(ParkingSpot))]
        public ICollection<ParkingSpotOccupation> ParkingSpotOccupations { get; set; }
    }
}
