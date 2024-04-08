using SmartParkInnovate.Core.Models.ParkingSpot;

namespace SmartParkInnovate.Core.Contracts.AdminServiceContracts.AdminParkingService
{
    public interface IAdminParkingService
    {
        public Task<List<ParkingSpotViewModel>> ParkingSpots();

        public Task AllOccupations(int id);

        public Task KickUserFromParkingSpot(int id);

        public Task DeleteParkingSpotOccupation(int id);

        public Task EnableParkingSpot(int id);

        public Task DisableParkingSpot(int id);
    }
}
