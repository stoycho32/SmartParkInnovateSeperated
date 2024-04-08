using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpotOccupationModel;
using SmartParkInnovate.Core.Models.VehicleModel;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.VehicleErrorMessages;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.WorkerErrorMessages;
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
                throw new InvalidOperationException(string.Format(VehicleAlreadyExistsErrorMessage));
            }

            Worker? worker = await this.repository.GetByIdAsync<Worker>(userId);

            if (worker == null)
            {
                throw new ArgumentException(InvalidWorkerErrorMessage);
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

        public async Task<VehicleDetailsViewModel> Details(int id, string userId)
        {
            VehicleDetailsViewModel? model = await this.repository.AllAsReadOnly<Vehicle>()
                .AsSplitQuery()
                .Where(c => c.Id == id)
                .Select(c => new VehicleDetailsViewModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    LicensePlate = c.LicensePlate,
                    WorkerUserName = c.Worker.UserName,
                    WorkerFullName = $"{c.Worker.FirstName} {c.Worker.LastName}",
                    IsDeleted = c.IsDeleted,
                    DeletedOn = c.DeletedOn,
                    Occupations = c.ParkingSpotOccupations
                    .Where(c => c.Vehicle.WorkerId == userId)
                    .Select(c => new VehicleOccupationViewModel()
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
                throw new ArgumentException(string.Format(InvalidVehicleErrorMessage));
            }

            return model;
        }

        public async Task<List<VehicleViewModel>> MyVehicles(string userId)
        {
            List<VehicleViewModel> vehicles = await this.repository.AllAsReadOnly<Vehicle>()
                .AsSplitQuery()
                .Where(c => c.WorkerId == userId && c.IsDeleted == false)
                .Select(c => new VehicleViewModel()
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    LicensePlate = c.LicensePlate,
                    WorkerUserName = c.Worker.UserName,
                })
                .ToListAsync();

            return vehicles;
        }
    }
}
