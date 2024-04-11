using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.AdminModels.AdminParkingModels
{
    public class ParkingSpotAdminViewModel
    {
        public int Id { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [Required]
        public bool IsOccupied { get; set; }
    }
}
