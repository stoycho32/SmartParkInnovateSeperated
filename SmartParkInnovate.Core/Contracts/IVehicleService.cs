using SmartParkInnovate.Core.Models.VehicleModel;

namespace SmartParkInnovate.Core.Contracts
{
    public interface IVehicleService
    {
        public Task Add(string make, string model, string licensePlate, string userId);

        public Task Remove();

        public Task Details();

        public Task<List<VehicleViewModel>> All();

        public Task MyVehicles();
    }
}
