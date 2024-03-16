using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;

namespace SmartParkInnovate.Core.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IRepository repository;

        public ParkingService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task Use(int id, string userId, string licensePlate)
        {
            ParkingSpot? parkingSpot = await this.repository.GetByIdAsync<ParkingSpot>(id);
            Worker? worker = await this.repository.GetByIdAsync<Worker>(userId);

            Vehicle? vehicle = null;

            if (parkingSpot == null)
            {
                throw new ArgumentException("Invalid Parking Spot");
            }

            if (!parkingSpot.IsEnabled)
            {
                throw new InvalidOperationException("Parking Spot Is Not Available");
            }

            if (parkingSpot.IsOccupied)
            {
                throw new InvalidOperationException("Parking Spot Is Already In Use");
            }

            if (worker == null)
            {
                throw new ArgumentException("Invalid Credentials");
            }

            vehicle = worker.Vehicles.FirstOrDefault(c => c.LicensePlate == licensePlate);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid Vehicle");
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
                throw new ArgumentException("Invalid Parking Spot");
            }

            if (!parkingSpot.IsOccupied && parkingSpot.OccupationVehicle == null)
            {
                throw new InvalidOperationException("Parking Spot Is Not Occupied");
            }

            if (!parkingSpot.IsEnabled)
            {
                throw new InvalidOperationException("Parking Spot Is Not Available. Cannot Be Exited");
            }

            int? vehicleId = parkingSpot.OccupationVehicle.Id;

            ParkingSpotOccupation? occupation = await this.repository.All<ParkingSpotOccupation>()
                .FirstOrDefaultAsync(c => c.ParkingSpotId == id && c.Vehicle.Id == vehicleId && c.ExitDateTime == null);

            if (occupation == null)
            {
                throw new ArgumentException("Something Unexpected Occurred");
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
