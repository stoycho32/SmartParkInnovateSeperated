using SmartParkInnovate.Core.Models.AdminModels.AdminVehicleModels;

namespace SmartParkInnovate.Core.Contracts.AdminServiceContracts
{
    public interface IAdminVehicleService
    {
        public Task<IEnumerable<AdminVehicleViewModel>> AllVehicles();

        public Task Details();

        public Task RemoveVehicle();

        public Task ReturnVehicle();
    }
}
