using SmartParkInnovate.Core.Contracts;
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
                Vehicle = vehicle
            };

            await this.repository.AddAsync<ParkingSpotOccupation>(occupation);
            await this.repository.SaveChangesAsync();
        }

        public Task Exit()
        {
            throw new NotImplementedException();
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

        public Task All()
        {
            throw new NotImplementedException();
        }

        public Task NotOccupied()
        {
            throw new NotImplementedException();
        }

        public Task Occupied()
        {
            throw new NotImplementedException();
        }
    }
}
