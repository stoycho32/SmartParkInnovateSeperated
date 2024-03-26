using SmartParkInnovate.Infrastructure.Data.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.VehicleModel
{
    public class UseSpotVehicleFormModel
    {
        [Required]
        [LicensePlateFormat]
        public string LicensePlate { get; set; } = null!;
    }
}
