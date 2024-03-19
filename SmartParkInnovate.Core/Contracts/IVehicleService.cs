using SmartParkInnovate.Core.Models.VehicleModel;

namespace SmartParkInnovate.Core.Contracts
{
    public interface IVehicleService
    {
        public Task Add(string userId, VehicleViewModel vehicleModel);

        public Task Remove(int id, string userId);

        public Task Details(int id, string userId);

        public Task<List<VehicleViewModel>> All();

        public Task MyVehicles(string userId);
    }
}
