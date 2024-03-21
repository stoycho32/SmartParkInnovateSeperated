using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Core.Models.VehicleModel;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;

namespace SmartParkInnovate.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task Add(string userId, VehicleViewModel vehicleModel)
        {
            if (await this.repository
                .All<Vehicle>()
                .FirstOrDefaultAsync(c => c.LicensePlate == vehicleModel.LicensePlate) != null)
            {
                throw new InvalidOperationException(string.Format(VehicleErrorMessages.VehicleAlreadyExistsErrorMessage));
            }

            Worker? worker = await this.repository.GetByIdAsync<Worker>(userId);

            if (worker == null)
            {
                throw new ArgumentException(WorkerErrorMessages.InvalidWorkerErrorMessage);
            }

            Vehicle vehicle = new Vehicle()
            {
                Make = vehicleModel.Make,
                Model = vehicleModel.Model,
                LicensePlate = vehicleModel.LicensePlate,
                WorkerId = worker.Id,
                Worker = worker
            };

            await this.repository.AddAsync<Vehicle>(vehicle);
            await this.repository.SaveChangesAsync();
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

        public async Task<VehicleViewModel> Details(int id, string userId)
        {
            var vehicle = await this.repository.All<Vehicle>()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (vehicle == null)
            {

            }
        }

        public async Task<List<VehicleViewModel>> MyVehicles(string userId)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
