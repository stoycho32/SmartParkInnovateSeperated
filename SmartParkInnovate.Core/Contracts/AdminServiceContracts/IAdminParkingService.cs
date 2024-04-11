using SmartParkInnovate.Core.Models.AdminModels.AdminParkingModels;

namespace SmartParkInnovate.Core.Contracts.AdminServiceContracts
{
    public interface IAdminParkingService
    {
        public Task<List<ParkingSpotAdminViewModel>> ParkingSpots();

        public Task AddParkingSpot();

        public Task<IEnumerable<ParkingOccupationsAdminViewModel>> AllOccupations(int? id);

        public Task KickUserFromParkingSpot(int id);

        public Task DeleteParkingSpotOccupation(int id);

        public Task EnableParkingSpot(int id);

        public Task DisableParkingSpot(int id);
    }
}
