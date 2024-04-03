using SmartParkInnovate.Core.Models.VehicleModel;

namespace SmartParkInnovate.Core.Contracts
{
    public interface IVehicleService
    {
        public Task Add(string userId, VehicleFormModel vehicleModel);

        public Task<VehicleDetailsViewModel> Details(int id);

        public List<VehicleViewModel> MyVehicles(string userId);

        public Task Remove(int id);

        public Task Return(int id);
    }
}
