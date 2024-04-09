using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Core.Models.ParkingSpotOccupationModel;
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

        public async Task<List<ParkingSpotViewModel>> ParkingSpots()
        {
            List<ParkingSpotViewModel> spots = await repository.AllAsReadOnly<ParkingSpot>()
                .Select(c => new ParkingSpotViewModel()
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

        public async Task<IEnumerable<ParkingOccupationsViewModel>> AllOccupations(int? id)
        {
            IEnumerable<ParkingOccupationsViewModel> parkingOccupations = parkingOccupations = await this.repository.All<ParkingSpotOccupation>()
                .Select(c => new ParkingOccupationsViewModel()
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

            return parkingOccupations;
        }

        public Task KickUserFromParkingSpot(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteParkingSpotOccupation(int id)
        {
            throw new NotImplementedException();
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
