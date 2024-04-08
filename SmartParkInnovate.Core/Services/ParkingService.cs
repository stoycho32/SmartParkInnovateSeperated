using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Core.Models.ParkingSpotModel;
using SmartParkInnovate.Core.Models.ParkingSpotOccupationsViewModel;
using SmartParkInnovate.Core.Models.VehicleModel;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.ParkingSpotErrorMessages;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.WorkerErrorMessages;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.VehicleErrorMessages;

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
            ParkingSpot? parkingSpot = await this.repository.All<ParkingSpot>()
                .Include(c => c.ParkingSpotOccupations)
                .AsSplitQuery()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();


            Worker? worker = await this.repository.All<Worker>()
                .Include(c => c.Vehicles)
                .ThenInclude(c => c.ParkingSpotOccupations)
                .AsSplitQuery()
                .FirstOrDefaultAsync(c => c.Id == userId);

            Vehicle? vehicle = null;

            if (parkingSpot == null)
            {
                throw new ArgumentException(string.Format(InvalidParkingSpotErrorMessage));
            }

            if (worker == null)
            {
                throw new ArgumentException(string.Format(InvalidWorkerErrorMessage));
            }

            if (!parkingSpot.IsEnabled)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotIsDisabledErrorMessage));
            }

            if (parkingSpot.IsOccupied)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotAlreadyInUseErrorMessage));
            }

            vehicle = worker.Vehicles.FirstOrDefault(c => c.LicensePlate == vehicleModel.LicensePlate);

            if (vehicle == null)
            {
                throw new ArgumentException(string.Format(InvalidVehicleErrorMessage));
            }

            if (vehicle.ParkingSpotOccupations.Any(c => c.ExitDateTime == null))
            {
                throw new InvalidOperationException(string.Format(VehicleAlreadyParkedErrorMessage));
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
                .AsSplitQuery()
                .Include(c => c.ParkingSpotOccupations).FirstOrDefaultAsync(c => c.Id == id);

            Worker? worker = await this.repository.All<Worker>()
                .AsSplitQuery()
                .Include(c => c.Vehicles)
                .FirstOrDefaultAsync(c => c.Id == userId);

            if (parkingSpot == null)
            {
                throw new ArgumentException(string.Format(InvalidParkingSpotErrorMessage));
            }

            if (worker == null)
            {
                throw new ArgumentException(string.Format(InvalidWorkerErrorMessage));
            }

            if (!parkingSpot.IsEnabled)
            {
                throw new InvalidOperationException(ParkingSpotIsDisabledErrorMessage);
            }

            if (!parkingSpot.IsOccupied)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotNotOccupiedErrorMessage));
            }

            ParkingSpotOccupation? occupation = parkingSpot.ParkingSpotOccupations
                .FirstOrDefault(c => c.ParkingSpotId == parkingSpot.Id && c.ExitDateTime == null);

            if (occupation == null)
            {
                throw new ArgumentException(string.Format(ParkingSpotWasNotUsed));
            }

            if (worker.Vehicles.FirstOrDefault(c => c.LicensePlate == occupation.Vehicle.LicensePlate) == null)
            {
                throw new InvalidOperationException(string.Format(VehicleDoesNotBelongToWorker));
            }

            parkingSpot.IsOccupied = false;

            occupation.ExitDateTime = DateTime.Now;

            await this.repository.SaveChangesAsync();
        }

        public async Task<ParkingSpotDetailsModel> Details(int id, string userId)
        {
            ParkingSpotDetailsModel? model = await this.repository.AllAsReadOnly<ParkingSpot>()
               .AsSplitQuery()
               .Where(c => c.Id == id)
               .Select(c => new ParkingSpotDetailsModel()
               {
                   CurrentUserId = userId,
                   ParkingSpotDetailsViewModel = new ParkingSpotDetailsViewModel()
                   {
                       Id = id,
                       IsEnabled = c.IsEnabled,
                       IsOccupied = c.IsOccupied,
                       ParkingSpotOccupations = c.ParkingSpotOccupations
                       .Where(c => c.Vehicle.WorkerId == userId)
                       .Select(p => new ParkingSpotOccupationViewModel()
                       {
                           EnterDateTime = p.EnterDateTime,
                           ExitDateTime = p.ExitDateTime
                       }).OrderByDescending(c => c.EnterDateTime).ToList()
                   }
               }).FirstOrDefaultAsync();

            if (model == null)
            {
                throw new ArgumentException(string.Format(InvalidParkingSpotErrorMessage));
            }

            return model;
        }

        public async Task<List<ParkingSpotViewModel>> All()
        {
            var parkingSpots = await this.repository.AllAsReadOnly<ParkingSpot>()
                .AsNoTracking()
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
