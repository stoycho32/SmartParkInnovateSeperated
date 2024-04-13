using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.AdminModels.AdminVehicleModels;
using SmartParkInnovate.Infrastructure.Data.Models;
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

        public async Task<IEnumerable<AdminVehicleViewModel>> AllVehicles(string? licensePlate, string? ownerEmail, string? make, string? model)
        {
            IEnumerable<AdminVehicleViewModel> vehicles = await this.repository.AllAsReadOnly<Vehicle>()
                .Select(c => new AdminVehicleViewModel()
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    LicensePlate = c.LicensePlate,
                    OwnerEmail = c.Worker.UserName,
                    IsDeleted = c.IsDeleted

                }).ToListAsync();

            if (licensePlate != null)
            {
                vehicles = vehicles.Where(c => c.LicensePlate.Contains(licensePlate)).ToList();
            }

            if (ownerEmail != null)
            {
                vehicles = vehicles.Where(c => c.OwnerEmail.Contains(ownerEmail)).ToList();
            }

            if (make != null)
            {
                vehicles = vehicles.Where(c => c.Make.Contains(make)).ToList();
            }

            if (model != null)
            {
                vehicles = vehicles.Where(c => c.Model.Contains(model)).ToList();
            }

            return vehicles;
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
