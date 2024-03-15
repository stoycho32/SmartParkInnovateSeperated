using Microsoft.AspNetCore.Identity;
using SmartParkInnovate.Core.Contracts;
using SmartParkInnovate.Infrastructure.Repository;
using System.Runtime.CompilerServices;

namespace SmartParkInnovate.Core.Services
{
    public class ParkingService : IParkingService
    {
        private IRepository repository;

        public ParkingService(IRepository repository)
        {
            this.repository = repository;
        }

        public Task Use()
        {
            throw new NotImplementedException();
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
