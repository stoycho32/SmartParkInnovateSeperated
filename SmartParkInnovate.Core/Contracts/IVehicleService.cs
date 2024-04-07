using SmartParkInnovate.Core.Models.VehicleModel;

namespace SmartParkInnovate.Core.Contracts
{
    public interface IVehicleService
    {
        public Task Add(string userId, VehicleFormModel vehicleModel);

        public Task<VehicleDetailsViewModel> Details(int id, string userId);

        public Task<List<VehicleViewModel>> MyVehicles(string userId);
    }
}
