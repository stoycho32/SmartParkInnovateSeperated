using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Core.Models.ParkingSpotOccupationModel;

namespace SmartParkInnovate.Core.Contracts.AdminServiceContracts
{
    public interface IAdminParkingService
    {
        public Task<List<ParkingSpotViewModel>> ParkingSpots();

        public Task AddParkingSpot();

        public Task<IEnumerable<ParkingOccupationsViewModel>> AllOccupations(int? id);

        public Task KickUserFromParkingSpot(int id);

        public Task DeleteParkingSpotOccupation(int id);

        public Task EnableParkingSpot(int id);

        public Task DisableParkingSpot(int id);
    }
}
