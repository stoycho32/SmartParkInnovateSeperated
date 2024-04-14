using SmartParkInnovate.Core.Models.ParkingSpot;
using SmartParkInnovate.Core.Models.ParkingSpotModel;
using SmartParkInnovate.Core.Models.VehicleModel;

namespace SmartParkInnovate.Core.Contracts
{
    public interface IParkingService
    { 
        public Task Use(int id, string userId, UseSpotVehicleFormModel vehicleModel);

        public Task Exit(int id, string userId);

        public Task<ParkingSpotDetailsModel> Details(int id, string userId);

        public Task<IEnumerable<ParkingSpotViewModel>> ParkingSpots();

        public GeneralParkingInformationModel GeneralParkingSpotInformation();
    }
}
