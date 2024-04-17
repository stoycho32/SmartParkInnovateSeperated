using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.AdminModels.AdminParkingModels;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.ParkingSpotErrorMessages;

namespace SmartParkInnovate.Core.Services.AdminService
{
    public class AdminParkingService : IAdminParkingService
    {
        private readonly IRepository repository;

        public AdminParkingService(IRepository repository)
        {
            this.repository = repository;
        }


        /// <summary>
        /// Gets general admin report for the parking spots. Free, Occupied, Total, Occupied from today and from yesterday
        /// </summary>
        /// <returns>general information detailed model</returns>
        public  GeneralAdminInformationModel GetAdminReport()
        {
            DateTime todayDate = DateTime.Today;
            DateTime yesterdayDate = todayDate.AddDays(-1);

            GeneralAdminInformationModel adminInfoModel = new GeneralAdminInformationModel();

            adminInfoModel.FreeParkingSpots =  this.repository.AllAsReadOnly<ParkingSpot>().Where(c => c.IsOccupied == false).Count();

            adminInfoModel.OccupiedParkingSpots = this.repository.AllAsReadOnly<ParkingSpot>().Where(c => c.IsOccupied == true).Count();

            adminInfoModel.TotalParkingSpots = this.repository.AllAsReadOnly<ParkingSpot>().Count();

            adminInfoModel.SpotsOccupiedForToday = this.repository.AllAsReadOnly<ParkingSpotOccupation>().Where(c => c.EnterDateTime.Year == todayDate.Year 
            && c.EnterDateTime.Month == todayDate.Month 
            && c.EnterDateTime.Day == todayDate.Day).Count();

            adminInfoModel.SpotsOccupiedForYesterday = this.repository.AllAsReadOnly<ParkingSpotOccupation>().Where(c => c.EnterDateTime.Year == yesterdayDate.Year
            && c.EnterDateTime.Month == yesterdayDate.Month
            && c.EnterDateTime.Day == yesterdayDate.Day).Count();


            return adminInfoModel;
        }



        /// <summary>
        /// Getting all the parking spots in order to manage them
        /// </summary>
        /// <returns>collection of the parking spots in the system</returns>
        public async Task<IEnumerable<ParkingSpotAdminViewModel>> ParkingSpots()
        {
            List<ParkingSpotAdminViewModel> spots = await repository.AllAsReadOnly<ParkingSpot>()
                .Select(c => new ParkingSpotAdminViewModel()
                {
                    Id = c.Id,
                    IsOccupied = c.IsOccupied,
                    IsEnabled = c.IsEnabled
                }).ToListAsync();

            return spots;
        }


        /// <summary>
        /// allows the admin to add a parking spot
        /// </summary>
        public async Task AddParkingSpot()
        {
            ParkingSpot createdSpot = new ParkingSpot();

            await repository.AddAsync(createdSpot);
            await repository.SaveChangesAsync();
        }


        /// <summary>
        /// Getting all the occupations for all the parking spots
        /// </summary>
        /// <param name="id">using parking spot id as filter</param>
        /// <param name="licensePlate">using license plate for specific vehicles</param>
        /// <param name="userEmail">using user email in order to find a specific user in order to view his occupations</param>
        /// <returns>collection of occupations</returns>
        public async Task<IEnumerable<ParkingOccupationsAdminViewModel>> AllOccupations(int? id, string? licensePlate, string? userEmail)
        {
            IEnumerable<ParkingOccupationsAdminViewModel> parkingOccupations = parkingOccupations = await this.repository.All<ParkingSpotOccupation>()
                .Select(c => new ParkingOccupationsAdminViewModel()
                {
                    ParkingSpotId = c.ParkingSpotId,
                    VehicleLicensePlate = c.Vehicle.LicensePlate,
                    VehicleOwnerEmail = c.Vehicle.Worker.UserName,
                    VehicleOwnerFullName = $"{c.Vehicle.Worker.FirstName} {c.Vehicle.Worker.LastName}",
                    EnterDateTime = c.EnterDateTime,
                    ExitDateTime = c.ExitDateTime
                })
                .OrderByDescending(c => c.EnterDateTime)
                .ToListAsync();

            if (id != null)
            {
                parkingOccupations = parkingOccupations.Where(c => c.ParkingSpotId == id).ToList();
            }

            if (licensePlate != null)
            {
                parkingOccupations = parkingOccupations.Where(c => c.VehicleLicensePlate.Contains(licensePlate)).ToList();
            }

            if (userEmail != null)
            {
                parkingOccupations = parkingOccupations.Where(c => c.VehicleOwnerEmail.Contains(userEmail)).ToList();
            }

            return parkingOccupations;
        }



        /// <summary>
        /// Allows the admin to kick a user from a specific parking spot
        /// </summary>
        /// <param name="id">the id of the parking spot</param>
        /// <exception cref="ArgumentException">If the parking spot is not available</exception>
        /// <exception cref="InvalidOperationException">If the occupation cannot be found (not occupied)</exception>
        public async Task KickUserFromParkingSpot(int id)
        {
            ParkingSpot? parkingSpot = await this.repository.All<ParkingSpot>()
                .Include(c => c.ParkingSpotOccupations)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            ParkingSpotOccupation? occupation
                = parkingSpot.ParkingSpotOccupations.FirstOrDefault(c => c.ExitDateTime == null);

            if (parkingSpot == null)
            {
                throw new ArgumentException(string.Format(InvalidParkingSpotErrorMessage));
            }

            if (occupation == null)
            {
                throw new InvalidOperationException(ParkingSpotNotOccupiedErrorMessage);
            }

            occupation.ExitDateTime = DateTime.Now;
            parkingSpot.IsOccupied = false;

            await this.repository.SaveChangesAsync();
        }


        /// <summary>
        /// Allows the admin to enable selected parking spot
        /// </summary>
        /// <param name="id">id of the parking spot</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">if the spot is invalid</exception>
        /// <exception cref="InvalidOperationException">if the spot is not disabled</exception>
        public async Task EnableParkingSpot(int id)
        {
            ParkingSpot? spotToEnable = await repository.GetByIdAsync<ParkingSpot>(id);

            if (spotToEnable == null)
            {
                throw new ArgumentException(string.Format(InvalidParkingSpotErrorMessage));
            }

            if (spotToEnable.IsEnabled)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotAlreadyEnabledErrorMessage));
            }

            spotToEnable.IsEnabled = true;
            await repository.SaveChangesAsync();
        }



        /// <summary>
        /// Allows the admin to disable selected parking spot
        /// </summary>
        /// <param name="id">id of the parking spot</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">if the spot is invalid</exception>
        /// <exception cref="InvalidOperationException">if the spot is already disabled</exception>
        public async Task DisableParkingSpot(int id)
        {
            ParkingSpot? spotToEnable = await repository.GetByIdAsync<ParkingSpot>(id);

            if (spotToEnable == null)
            {
                throw new ArgumentException(string.Format(InvalidParkingSpotErrorMessage));
            }

            if (!spotToEnable.IsEnabled)
            {
                throw new InvalidOperationException(string.Format(ParkingSpotAlreadyDisabledErrorMessage));
            }

            spotToEnable.IsEnabled = false;
            await repository.SaveChangesAsync();
        }
    }
}
