using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Core.Models.ParkingSpotOccupationsViewModel;
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

        public async Task Use(int id, string userId, UseSpotVehicleFormModel vehicleModel)
        {
            ParkingSpot? parkingSpot = await this.repository.GetByIdAsync<ParkingSpot>(id);
            Worker? worker = await this.repository.All<Worker>()
                .Include(c => c.Vehicles)
                .ThenInclude(c => c.ParkingSpotOccupations)
                .FirstOrDefaultAsync(c => c.Id == userId);

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

            if (vehicle.ParkingSpotOccupations.Any(c => c.ExitDateTime == null))
            {
                throw new InvalidOperationException(string.Format(VehicleErrorMessages.VehicleAlreadyParkedErrorMessage));
            }

            parkingSpot.IsOccupied = true;

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
            ParkingSpot? parkingSpot = await this.repository.All<ParkingSpot>()
                .Include(c => c.ParkingSpotOccupations).FirstOrDefaultAsync(c => c.Id == id);

            Worker? worker = await this.repository.All<Worker>()
                .Include(c => c.Vehicles)
                .FirstOrDefaultAsync(c => c.Id == userId);

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

            if (!parkingSpot.IsOccupied)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotErrorMessages.ParkingSpotNotOccupiedErrorMessage));
            }

            ParkingSpotOccupation? occupation = parkingSpot.ParkingSpotOccupations
                .FirstOrDefault(c => c.ParkingSpotId == parkingSpot.Id && c.ExitDateTime == null);

            if (occupation == null)
            {
                throw new ArgumentException(string.Format(ParkingSpotErrorMessages.ParkingSpotWasNotUsed));
            }

            if (worker.Vehicles.FirstOrDefault(c => c.LicensePlate == occupation.Vehicle.LicensePlate) == null)
            {
                throw new InvalidOperationException(string.Format(VehicleErrorMessages.VehicleDoesNotBelongToWorker));
            }

            parkingSpot.IsOccupied = false;

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
            ParkingSpotDetailsViewModel? model = await this.repository.All<ParkingSpot>()
                .Include(c => c.ParkingSpotOccupations)
                .ThenInclude(c => c.Vehicle)
                .ThenInclude(c => c.Worker)
                .Where(c => c.Id == id)
                .Select(c => new ParkingSpotDetailsViewModel()
                {
                    Id = id,
                    IsEnabled = c.IsEnabled,
                    IsOccupied = c.IsOccupied,
                    OccupationsCount = c.ParkingSpotOccupations.Count,
                    ParkingSpotOccupations = c.ParkingSpotOccupations.Select(p => new ParkingSpotOccupationViewModel()
                    {
                        VehicleId = p.VehicleId,
                        OccupationVehicleLicensePlate = p.Vehicle.LicensePlate,
                        OccupationVehicleWorkerUserName = p.Vehicle.Worker.UserName,
                        EnterDateTime = p.EnterDateTime,
                        ExitDateTime = p.ExitDateTime
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (model == null)
            {
                throw new ArgumentException(string.Format(ParkingSpotErrorMessages.InvalidParkingSpotErrorMessage));
            }

            return model;
        }

        public async Task<List<ParkingSpotViewModel>> All()
        {
            var parkingSpots = await this.repository.All<ParkingSpot>()
                .Select(c => new ParkingSpotViewModel()
                {
                    Id = c.Id,
                    IsEnabled = c.IsEnabled,
                    IsOccupied = c.IsOccupied,
                }).ToListAsync();

            return parkingSpots;
        }
    }
}
