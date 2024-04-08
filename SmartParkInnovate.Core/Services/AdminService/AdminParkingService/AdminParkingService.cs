using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts.AdminParkingService;
using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;

namespace SmartParkInnovate.Core.Services.AdminService.AdminParkingService
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
            List<ParkingSpotViewModel> spots = await this.repository.AllAsReadOnly<ParkingSpot>()
                .Select(c => new ParkingSpotViewModel()
                {
                    Id = c.Id,
                    IsOccupied = c.IsOccupied,
                    IsEnabled = c.IsEnabled
                }).ToListAsync();

            return spots;
        }

        public Task AllOccupations(int id)
        {
            throw new NotImplementedException();
        }

        public Task KickUserFromParkingSpot(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteParkingSpotOccupation(int id)
        {
            throw new NotImplementedException();
        }

        public Task EnableParkingSpot(int id)
        {
            throw new NotImplementedException();
        }

        public Task DisableParkingSpot(int id)
        {
            throw new NotImplementedException();
        }
    }
}
