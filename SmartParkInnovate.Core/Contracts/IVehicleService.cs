using SmartParkInnovate.Core.Models.VehicleModel;

namespace SmartParkInnovate.Core.Contracts
{
    public interface IVehicleService
    {
        public Task Add(string userId, VehicleFormModel vehicleModel);

        public Task<VehicleViewModel> Details(int id, string userId);

        public Task<List<VehicleViewModel>> All();

        public List<VehicleViewModel> MyVehicles(string userId);

        public Task Remove(int id, string userId);
    }
}
