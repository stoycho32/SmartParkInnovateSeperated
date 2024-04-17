using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Core.Models.ParkingSpotModel;
using SmartParkInnovate.Core.Models.ParkingSpotOccupationModel;
using SmartParkInnovate.Core.Models.VehicleModel;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.ParkingSpotErrorMessages;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.VehicleErrorMessages;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.WorkerErrorMessages;

namespace SmartParkInnovate.Core.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IRepository repository;

        public ParkingService(IRepository repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// This is a use parking spot function which allows the user to use a specific parking spot.
        /// </summary>
        /// <param name="id">The Id of the parking spot</param>
        /// <param name="userId">the id of the user</param>
        /// <param name="vehicleModel">the form model of the vehicle (LicensePlate only)</param>
        /// <exception cref="ArgumentException">It gets exception if an invalid object is passed for the operation</exception>
        /// <exception cref="InvalidOperationException">It gets exception if a user makes an attempt to use already occupied parking spot</exception>
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

            if (vehicle == null || vehicle.IsDeleted == true)
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


        /// <summary>
        /// This is exit parking spot functionality which allows the user to leave the specified parking spot
        /// </summary>
        /// <param name="id">the id of the parking spot</param>
        /// <param name="userId">the id of the user</param>
        /// <exception cref="ArgumentException">It gets exception if an invalid object is passed for the operation</exception>
        /// <exception cref="InvalidOperationException">It gets exception if the user tries to leave unoccupied parking spot</exception>
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

        /// <summary>
        /// Provides details for the selected parking spot
        /// </summary>
        /// <param name="id">the id of the parking spot</param>
        /// <param name="userId">The user id is used in order to add the current user to the view model so we can check if he can leave the spot (if decided)</param>
        /// <returns>Parking Spot Details object</returns>
        /// <exception cref="ArgumentException">It gets exception if the parking spot is invalid (Non existing)</exception>
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


        /// <summary>
        /// It gets all the parking spots that are added by the admin or seeded in the database as default.
        /// </summary>
        /// <returns>A collection of parking spots</returns>
        public async Task<IEnumerable<ParkingSpotViewModel>> ParkingSpots()
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


        /// <summary>
        /// This is the general parking spot information, it allows the user to know the total count, total free and total occupied spots. 
        /// Also provides the user with today's date
        /// </summary>
        /// <returns>general information object</returns>
        public GeneralParkingInformationModel GeneralParkingSpotInformation()
        {
            int freeSpots =  repository.AllAsReadOnly<ParkingSpot>().Where(c => c.IsOccupied == false).Count();
            int occupiedSpots = repository.AllAsReadOnly<ParkingSpot>().Where(c => c.IsOccupied == true).Count();
            int totalSpots = repository.AllAsReadOnly<ParkingSpot>().Count();

            GeneralParkingInformationModel generalInformationModel = new GeneralParkingInformationModel();

            generalInformationModel.FreeParkingSpotsCount = freeSpots;
            generalInformationModel.OccupiedParkingSpotsCount =  occupiedSpots;
            generalInformationModel.TotalParkingSpotsCount = totalSpots;

            return generalInformationModel;
        }
    }
}
