namespace SmartParkInnovate.Core.Contracts
{
    public interface IParkingService
    {
        public Task Use(int id, string userId, string licensePlate);

        public Task Exit();

        public Task Details();

        public Task Enable();

        public Task Disable();

    }
}
