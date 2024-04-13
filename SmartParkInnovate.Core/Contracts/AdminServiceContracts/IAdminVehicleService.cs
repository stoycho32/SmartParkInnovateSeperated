using SmartParkInnovate.Core.Models.AdminModels.AdminVehicleModels;

namespace SmartParkInnovate.Core.Contracts.AdminServiceContracts
{
    public interface IAdminVehicleService
    {
        public Task<IEnumerable<AdminVehicleViewModel>> AllVehicles(string? licensePlate, string? ownerEmail, string? make, string? model);

        public Task<AdminVehicleDetailsModel> Details(int id);

        public Task RemoveVehicle();

        public Task ReturnVehicle();
    }
}
