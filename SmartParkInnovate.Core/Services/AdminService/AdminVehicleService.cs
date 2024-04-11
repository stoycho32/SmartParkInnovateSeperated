using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.AdminModels.AdminVehicleModels;
using SmartParkInnovate.Infrastructure.Repository;

namespace SmartParkInnovate.Core.Services.AdminService
{
    public class AdminVehicleService : IAdminVehicleService
    {
        private readonly IRepository repository;

        public AdminVehicleService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<AdminVehicleViewModel>> AllVehicles()
        {
            IEnumerable<AdminVehicleViewModel> vehicles = await this.
        }

        public Task Details()
        {
            throw new NotImplementedException();
        }

        public Task RemoveVehicle()
        {
            throw new NotImplementedException();
        }

        public Task ReturnVehicle()
        {
            throw new NotImplementedException();
        }
    }
}
