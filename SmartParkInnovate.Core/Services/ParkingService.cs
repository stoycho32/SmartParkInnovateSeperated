using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Core.Models.VehicleModel;
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

            if (!parkingSpot.IsEnabled)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotErrorMessages.ParkingSpotIsDisabledErrorMessage));
            }

            if (parkingSpot.IsOccupied)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotErrorMessages.ParkingSpotAlreadyInUseErrorMessage));
            }

            if (worker == null)
            {
                throw new ArgumentException(WorkerErrorMessages.InvalidWorkerErrorMessage);
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

            await this.repository.AddAsync<ParkingSpotOccupation>(occupation);
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

            if (worker == null)
            {
                throw new ArgumentException(string.Format(WorkerErrorMessages.InvalidWorkerErrorMessage));
            }

            if (!parkingSpot.IsOccupied && parkingSpot.OccupationVehicle == null)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotErrorMessages.ParkingSpotNotOccupiedErrorMessage));
            }

            if (!parkingSpot.IsEnabled)
            {
                throw new InvalidOperationException(ParkingSpotErrorMessages.ParkingSpotIsDisabledErrorMessage);
            }

            int? vehicleId = parkingSpot.OccupationVehicle.Id;

            ParkingSpotOccupation? occupation = await this.repository.All<ParkingSpotOccupation>()
                .FirstOrDefaultAsync(c => c.ParkingSpotId == id && c.Vehicle.Id == vehicleId && c.ExitDateTime == null);

            if (occupation == null)
            {
                throw new ArgumentException(string.Format(GeneralErrorMessages.SomethingUnexpectedOccuredErrorMessage));
            }

            parkingSpot.IsOccupied = false;
            parkingSpot.OccupationVehicleId = null;
            parkingSpot.OccupationVehicle = null;

            occupation.ExitDateTime = DateTime.Now;

            await this.repository.SaveChangesAsync();
        }

        public Task Details()
        {
            throw new NotImplementedException();
        }

        public Task Enable()
        {
            throw new NotImplementedException();
        }

        public Task Disable()
        {
            throw new NotImplementedException();
        }
        
        public async Task<List<ParkingSpotViewModel>> All()
        {
            List<ParkingSpotViewModel> parkingSpots = await this.repository.All<ParkingSpot>()
                .Select(c => new ParkingSpotViewModel()
                {
                    Id = c.Id,
                    IsEnabled = c.IsEnabled,
                    IsOccupied = c.IsOccupied,
                    OccupationVehicleId = c.OccupationVehicleId,
                    OccupationVehicle = c.OccupationVehicle
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
                    OccupationVehicleId = c.OccupationVehicleId,
                    OccupationVehicle = c.OccupationVehicle
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
                    OccupationVehicleId = c.OccupationVehicleId,
                    OccupationVehicle = c.OccupationVehicle
                }).ToListAsync();

            return parkingSpots;
        }
    }
}
