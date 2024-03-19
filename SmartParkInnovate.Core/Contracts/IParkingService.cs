using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Core.Models.VehicleModel;

namespace SmartParkInnovate.Core.Contracts
{
    public interface IParkingService
    { 
        public Task Use(int id, string userId, VehicleViewModel vehicleModel);

        public Task Exit(int id, string userId);

        public Task<ParkingSpotDetailsViewModel> Details(int id);

        public Task Enable();

        public Task Disable();

        public Task<List<ParkingSpotViewModel>> All();

        public Task<List<ParkingSpotViewModel>> NotOccupied();

        public Task<List<ParkingSpotViewModel>> Occupied();
    }
}
