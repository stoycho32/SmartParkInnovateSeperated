namespace SmartParkInnovate.Core.Contracts.AdminServiceContracts.AdminParkingService
{
    public interface IAdminParkingService
    {
        public Task ParkingSpots();

        public Task GetParkingSpotDetails(int id);

        public Task KickUserFromParkingSpot(int id);

        public Task DeleteParkingSpotOccupation(int id);

        public Task EnableParkingSpot(int id);

        public Task DisableParkingSpot(int id);
    }
}
