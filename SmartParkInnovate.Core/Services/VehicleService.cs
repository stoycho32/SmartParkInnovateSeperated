using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Infrastructure.Repository;

namespace SmartParkInnovate.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }

        public Task Add(string make, string model, string licensePlate, string userId)
        {
            throw new NotImplementedException();
        }

        public Task All()
        {
            throw new NotImplementedException();
        }

        public Task Details()
        {
            throw new NotImplementedException();
        }

        public Task MyVehicles()
        {
            throw new NotImplementedException();
        }

        public Task Remove()
        {
            throw new NotImplementedException();
        }
    }
}
