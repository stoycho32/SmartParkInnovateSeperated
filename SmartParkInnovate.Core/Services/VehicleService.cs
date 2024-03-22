using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
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

        public async Task Add(string userId, VehicleFormModel vehicleModel)
        {
            bool isVehicleAlreadyAdded = await this.repository
                .All<Vehicle>().FirstOrDefaultAsync(c => c.LicensePlate == vehicleModel.LicensePlate) != null;



            if (isVehicleAlreadyAdded)
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

            worker.Vehicles.Add(vehicle);
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
                    WorkerUserName = c.Worker.UserName,
                    IsDeleted = c.IsDeleted,
                    DeletedOn = c.DeletedOn
                }).ToListAsync();

            return vehicles;
        }

        public async Task<VehicleViewModel> Details(int id, string userId)
        {
            var vehicle = await this.repository.All<Vehicle>()
                .Include(c => c.ParkingSpotOccupations)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (vehicle == null)
            {
                throw new ArgumentException(string.Format(VehicleErrorMessages.InvalidVehicleErrorMessage));
            }

            VehicleViewModel model = new VehicleViewModel()
            {
                Id = vehicle.Id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                LicensePlate = vehicle.LicensePlate,
                WorkerId = vehicle.WorkerId,
                WorkerUserName = vehicle.Worker.UserName,
                IsDeleted = vehicle.IsDeleted,
                DeletedOn = vehicle.DeletedOn
            };

            return model;
        }

        public List<VehicleViewModel> MyVehicles(string userId)
        {
            List<VehicleViewModel> vehicles = this.repository.AllAsReadOnly<Vehicle>()
                .Select(c => new VehicleViewModel()
                {
                    Id= c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    LicensePlate = c.LicensePlate,
                    WorkerId = c.WorkerId,
                    WorkerUserName = c.Worker.UserName,
                    IsDeleted = c.IsDeleted,
                    DeletedOn = c.DeletedOn
                }).Where(c => c.WorkerId == userId)
                .ToList();

            return vehicles;
        }

        public async Task Remove(int id, string userId)
        {
            var vehicleToRemove = await this.repository.GetByIdAsync<Vehicle>(id);

            if (vehicleToRemove == null)
            {
                throw new ArgumentException(string.Format(VehicleErrorMessages.InvalidVehicleErrorMessage));
            }

            vehicleToRemove.IsDeleted = true;
            vehicleToRemove.DeletedOn = DateTime.Now;

            await this.repository.SaveChangesAsync();
        }
    }
}
