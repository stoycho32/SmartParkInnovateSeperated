using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.VehicleModel
{
    public class UseSpotVehicleModel
    {
        [Required]
        [LicensePlateFormat]
        public string LicensePlate { get; set; } = null!;
    }
}
