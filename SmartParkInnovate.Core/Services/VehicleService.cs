using SmartParkInnovate.Infrastructure.Repository;

namespace SmartParkInnovate.Core.Services
{
    public class VehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }



    }
}
