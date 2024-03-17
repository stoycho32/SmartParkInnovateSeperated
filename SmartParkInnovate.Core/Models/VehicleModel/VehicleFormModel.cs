using SmartParkInnovate.Infrastructure.Data.Attributes;

namespace SmartParkInnovate.Core.Models.Vehicle
{
    public class VehicleFormModel
    {
        [LicensePlateFormat]
        public string LicensePlate { get; set; }
    }
}
