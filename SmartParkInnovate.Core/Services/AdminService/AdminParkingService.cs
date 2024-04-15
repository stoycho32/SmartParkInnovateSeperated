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

        public async Task AddParkingSpot()
        {
            ParkingSpot createdSpot = new ParkingSpot();

            await repository.AddAsync(createdSpot);
            await repository.SaveChangesAsync();
        }

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
