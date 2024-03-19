using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.VehicleModel;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;

namespace SmartParkInnovate.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }

        public Task Add(string make, string model, string licensePlate, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VehicleViewModel>> All()
        {
            List<VehicleViewModel> vehicles = await this.repository.All<Vehicle>()
                .Select(c => new VehicleViewModel()
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    LicensePlate = c.LicensePlate,
                    WorkerId = c.WorkerId,
                    Worker = c.Worker,
                    IsDeleted = c.IsDeleted,
                    DeletedOn = c.DeletedOn
                }).ToListAsync();

            return vehicles;
        }

        public Task Details()
        {
            throw new NotImplementedException();
        }

        public Task MyVehicles()
        {
            throw new NotImplementedException();
        }

        public Task Remove()
        {
            throw new NotImplementedException();
        }
    }
}
