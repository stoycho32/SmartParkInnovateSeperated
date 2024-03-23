using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Core.Models.ParkingSpotOccupationsViewModel;
using SmartParkInnovate.Core.Models.VehicleModel;
using SmartParkInnovate.Core.Models.WorkerModel;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages;

namespace SmartParkInnovate.Core.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IRepository repository;

        public ParkingService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task Use(int id, string userId, VehicleViewModel vehicleModel)
        {
            ParkingSpot? parkingSpot = await this.repository.GetByIdAsync<ParkingSpot>(id);
            Worker? worker = await this.repository.GetByIdAsync<Worker>(userId);

            Vehicle? vehicle = null;

            if (parkingSpot == null)
            {
                throw new ArgumentException(string.Format(ParkingSpotErrorMessages.InvalidParkingSpotErrorMessage));
            }

            if (worker == null)
            {
                throw new ArgumentException(WorkerErrorMessages.InvalidWorkerErrorMessage);
            }

            if (!parkingSpot.IsEnabled)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotErrorMessages.ParkingSpotIsDisabledErrorMessage));
            }

            if (parkingSpot.IsOccupied)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotErrorMessages.ParkingSpotAlreadyInUseErrorMessage));
            }

            vehicle = worker.Vehicles.FirstOrDefault(c => c.LicensePlate == vehicleModel.LicensePlate);

            if (vehicle == null)
            {
                throw new ArgumentException(string.Format(VehicleErrorMessages.InvalidVehicleErrorMessage));
            }

            parkingSpot.IsOccupied = true;
            parkingSpot.OccupationVehicleId = vehicle.Id;
            parkingSpot.OccupationVehicle = vehicle;

            ParkingSpotOccupation occupation = new ParkingSpotOccupation()
            {
                ParkingSpotId = parkingSpot.Id,
                ParkingSpot = parkingSpot,
                VehicleId = vehicle.Id,
                Vehicle = vehicle,
                ExitDateTime = null
            };

            parkingSpot.ParkingSpotOccupations.Add(occupation);
            await this.repository.SaveChangesAsync();
        }

        public async Task Exit(int id, string userId)
        {
            ParkingSpot? parkingSpot = await this.repository.GetByIdAsync<ParkingSpot>(id);
            Worker? worker = await this.repository.GetByIdAsync<Worker>(userId);

            if (parkingSpot == null)
            {
                throw new ArgumentException(string.Format(ParkingSpotErrorMessages.InvalidParkingSpotErrorMessage));
            }

            if (!parkingSpot.IsEnabled)
            {
                throw new InvalidOperationException(ParkingSpotErrorMessages.ParkingSpotIsDisabledErrorMessage);
            }

            if (worker == null)
            {
                throw new ArgumentException(string.Format(WorkerErrorMessages.InvalidWorkerErrorMessage));
            }

            if (!parkingSpot.IsOccupied && parkingSpot.OccupationVehicle == null)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotErrorMessages.ParkingSpotNotOccupiedErrorMessage));
            }

            int vehicleId = parkingSpot.OccupationVehicle.Id;

            if (worker.Vehicles.FirstOrDefault(c => c.Id == vehicleId) == null)
            {
                throw new ArgumentException(string.Format(VehicleErrorMessages.InvalidVehicleErrorMessage));
            }

            ParkingSpotOccupation? occupation = parkingSpot.ParkingSpotOccupations
                .FirstOrDefault(c => c.ParkingSpotId == parkingSpot.Id && c.Vehicle.Id == vehicleId && c.ExitDateTime == null);

            if (occupation == null)
            {
                throw new ArgumentException(string.Format(ParkingSpotErrorMessages.ParkingSpotWasNotUsed));
            }

            parkingSpot.IsOccupied = false;
            parkingSpot.OccupationVehicleId = null;
            parkingSpot.OccupationVehicle = null;

            occupation.ExitDateTime = DateTime.Now;

            await this.repository.SaveChangesAsync();
        }

        public async Task Enable(int id)
        {
            ParkingSpot? parkingSpot = await this.repository.GetByIdAsync<ParkingSpot>(id);

            if (parkingSpot == null)
            {
                throw new ArgumentException(string.Format(ParkingSpotErrorMessages.InvalidParkingSpotErrorMessage));
            }

            if (parkingSpot.IsEnabled)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotErrorMessages.ParkingSpotAlreadyEnabledErrorMessage));
            }

            parkingSpot.IsEnabled = true;

            await this.repository.SaveChangesAsync();
        }

        public async Task Disable(int id)
        {
            ParkingSpot? parkingSpot = await this.repository.GetByIdAsync<ParkingSpot>(id);

            if (parkingSpot == null)
            {
                throw new ArgumentException(string.Format(ParkingSpotErrorMessages.InvalidParkingSpotErrorMessage));
            }

            if (!parkingSpot.IsEnabled)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotErrorMessages.ParkingSpotAlreadyEnabledErrorMessage));
            }

            parkingSpot.IsEnabled = false;

            await this.repository.SaveChangesAsync();
        }

        public async Task<ParkingSpotDetailsViewModel> Details(int id)
        {
            ParkingSpot? parkingSpot = await this.repository.GetByIdAsync<ParkingSpot>(id);

            if (parkingSpot == null)
            {
                throw new ArgumentException(string.Format(ParkingSpotErrorMessages.InvalidParkingSpotErrorMessage));
            }

            ParkingSpotDetailsViewModel? model = new ParkingSpotDetailsViewModel()
            {
                Id = parkingSpot.Id,
                IsEnabled = parkingSpot.IsEnabled,
                IsOccupied = parkingSpot.IsOccupied,
                OccupationVehicleId = (parkingSpot.OccupationVehicleId == null) ? null : parkingSpot.OccupationVehicleId,
                OccupationVehicle = parkingSpot.OccupationVehicle == null ? null : new ParkingSpotDetailsVehicleViewModel()
                {
                    Make = parkingSpot.OccupationVehicle.Make,
                    Model = parkingSpot.OccupationVehicle.Model,
                    LicensePlate = parkingSpot.OccupationVehicle.LicensePlate,
                    WorkerId = parkingSpot.OccupationVehicle.Worker.Id,
                    WorkerUserName = parkingSpot.OccupationVehicle.Worker.UserName
                },
                ParkingSpotOccupations = parkingSpot.ParkingSpotOccupations
                .Select(c => new ParkingSpotOccupationViewModel()
                {
                    VehicleId = c.VehicleId,
                    OccupationVehicleLicensePlate = c.Vehicle.LicensePlate,
                    OccupationVehicleWorkerUserName = c.Vehicle.Worker.UserName
                }).ToList()
            };

            return model;
        }

        public async Task<List<ParkingSpotViewModel>> All()
        {
            List<ParkingSpotViewModel> parkingSpots = await this.repository.All<ParkingSpot>()
                .Select(c => new ParkingSpotViewModel()
                {
                    Id = c.Id,
                    IsEnabled = c.IsEnabled,
                    IsOccupied = c.IsOccupied,
                    OccupationVehicleId = (c.OccupationVehicleId == null) ? null : c.OccupationVehicleId,
                    OccupationVehicleLicensePlate = (c.OccupationVehicle == null) ? null : c.OccupationVehicle.LicensePlate,
                    OccupationVehicleWorkerUserName = (c.OccupationVehicle == null) ? null : c.OccupationVehicle.Worker.UserName,
                }).ToListAsync();

            return parkingSpots;
        }

        public async Task<List<ParkingSpotViewModel>> NotOccupied()
        {
            List<ParkingSpotViewModel> parkingSpots = await this.repository.All<ParkingSpot>()
                .Where(c => c.IsOccupied == false)
                .Select(c => new ParkingSpotViewModel()
                {
                    Id = c.Id,
                    IsEnabled = c.IsEnabled,
                    IsOccupied = c.IsOccupied,
                    OccupationVehicleId = (c.OccupationVehicleId == null) ? null : c.OccupationVehicleId,
                    OccupationVehicleLicensePlate = (c.OccupationVehicle == null) ? null : c.OccupationVehicle.LicensePlate,
                    OccupationVehicleWorkerUserName = (c.OccupationVehicle == null) ? null : c.OccupationVehicle.Worker.UserName,
                }).ToListAsync();

            return parkingSpots;
        }

        public async Task<List<ParkingSpotViewModel>> Occupied()
        {
            List<ParkingSpotViewModel> parkingSpots = await this.repository.All<ParkingSpot>()
                .Where(c => c.IsOccupied == true)
                .Select(c => new ParkingSpotViewModel()
                {
                    Id = c.Id,
                    IsEnabled = c.IsEnabled,
                    IsOccupied = c.IsOccupied,
                    OccupationVehicleId = (c.OccupationVehicleId == null) ? null : c.OccupationVehicleId,
                    OccupationVehicleLicensePlate = (c.OccupationVehicle == null) ? null : c.OccupationVehicle.LicensePlate,
                    OccupationVehicleWorkerUserName = (c.OccupationVehicle == null) ? null : c.OccupationVehicle.Worker.UserName,
                }).ToListAsync();

            return parkingSpots;
        }
    }
}
