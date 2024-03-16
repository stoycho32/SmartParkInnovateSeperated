namespace SmartParkInnovate.Core.Contracts
{
    public interface IParkingService
    { 
        public Task Use(int id, string userId, string licensePlate);

        public Task Exit(int id, string userId);

        public Task Details();

        public Task Enable();

        public Task Disable();

        public Task All();

        public Task NotOccupied();

        public Task Occupied();
    }
}
