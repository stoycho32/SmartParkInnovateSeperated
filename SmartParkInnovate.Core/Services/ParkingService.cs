using Microsoft.AspNetCore.Identity;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;
using System.Runtime.CompilerServices;

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
            Vehicle? vehicle = worker.Vehicles.FirstOrDefault(c => c.LicensePlate == licensePlate);

            if (parkingSpot == null)
            {
                throw new ArgumentException("Invalid Parking Spot");
            }

            if (!parkingSpot.IsEnabled)
            {
                throw new ArgumentException("Parking Spot Is Not Enabled");
            }

            if (parkingSpot.IsOccupied)
            {
                throw new ArgumentException("Parking Spot Is Already In Use");
            }

            if (worker == null)
            {
                throw new ArgumentException("Invalid Credentials");
            }

            if(vehicle == null)
            {
                throw new ArgumentException("Invalid Vehicle");
            }
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
    }
}
