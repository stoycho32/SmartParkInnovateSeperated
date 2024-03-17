using SmartParkInnovate.Infrastructure.Data.Attributes;

namespace SmartParkInnovate.Core.Models.VehicleModel
{
    public class VehicleFormModel
    {
        [LicensePlateFormat]
        public string LicensePlate { get; set; }
    }
}
