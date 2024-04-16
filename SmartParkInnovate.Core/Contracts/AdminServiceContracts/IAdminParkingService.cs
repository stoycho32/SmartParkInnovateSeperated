using SmartParkInnovate.Core.Models.AdminModels.AdminParkingModels;

namespace SmartParkInnovate.Core.Contracts.AdminServiceContracts
{
    public interface IAdminParkingService
    {
        public Task<string> GetAdminReport();

        public Task<IEnumerable<ParkingSpotAdminViewModel>> ParkingSpots();

        public Task AddParkingSpot();

        public Task<IEnumerable<ParkingOccupationsAdminViewModel>> AllOccupations(int? id, string? licensePlate, string? userEmail);

        public Task KickUserFromParkingSpot(int id);

        public Task EnableParkingSpot(int id);

        public Task DisableParkingSpot(int id);
    }
}
