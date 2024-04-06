using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.StatisticModel
{
    public class ParkingSpotOccupationStatistic
    {
        [Required]
        public int ParkingSpotId { get; set; }
        [Required]
        public DateTime EnterDateTime { get; set; }

        public DateTime? ExitDateTime { get; set; }
    }
}
