using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpotOccupationModel;
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

        public async Task<VehicleDetailsViewModel> Details(int id)
        {
            VehicleDetailsViewModel? model = await this.repository.All<Vehicle>()
                .AsSplitQuery()
                .Where(c => c.Id == id)
                .Select(c => new VehicleDetailsViewModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    LicensePlate = c.LicensePlate,
                    WorkerUserName = c.Worker.UserName,
                    IsDeleted = c.IsDeleted,
                    DeletedOn = c.DeletedOn,
                    Occupations = c.ParkingSpotOccupations.Select(c => new VehicleOccupationViewModel()
                    {
                        ParkingSpotId = c.ParkingSpot.Id,
                        EnterDateTime = c.EnterDateTime,
                        ExitDateTime = c.ExitDateTime,
                    })
                    .OrderByDescending(c => c.EnterDateTime)
                    .ToList()
                }).FirstOrDefaultAsync();

            if (model == null)
            {
                throw new ArgumentException(string.Format(VehicleErrorMessages.InvalidVehicleErrorMessage));
            }

            return model;
        }

        public List<VehicleViewModel> MyVehicles(string userId)
        {
            List<VehicleViewModel> vehicles = this.repository.AllAsReadOnly<Vehicle>()
                .AsSplitQuery()
                .Where(c => c.WorkerId == userId)
                .Select(c => new VehicleViewModel()
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    LicensePlate = c.LicensePlate,
                    WorkerUserName = c.Worker.UserName,
                })
                .ToList();

            return vehicles;
        }

        public async Task Remove(int id)
        {
            Vehicle? vehicleToRemove = await this.repository.GetByIdAsync<Vehicle>(id);

            if (vehicleToRemove == null)
            {
                throw new ArgumentException(string.Format(VehicleErrorMessages.InvalidVehicleErrorMessage));
            }

            if (vehicleToRemove.IsDeleted == true)
            {
                throw new InvalidOperationException(string.Format(VehicleErrorMessages.VehicleAlreadyDeletedErrorMessage));
            }

            vehicleToRemove.IsDeleted = true;
            vehicleToRemove.DeletedOn = DateTime.Now;

            await this.repository.SaveChangesAsync();
        }

        public async Task Return(int id)
        {
            Vehicle? vehicleToReturn = await this.repository.GetByIdAsync<Vehicle>(id);

            if (vehicleToReturn == null)
            {
                throw new ArgumentException(string.Format(VehicleErrorMessages.InvalidVehicleErrorMessage));
            }

            if (vehicleToReturn.IsDeleted == false)
            {
                throw new InvalidOperationException(string.Format(VehicleErrorMessages.VehicleIsNotDeletedErrorMessage));
            }

            vehicleToReturn.IsDeleted = false;
            vehicleToReturn.DeletedOn = null;

            await this.repository.SaveChangesAsync();
        }
    }
}
