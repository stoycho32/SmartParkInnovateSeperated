namespace SmartParkInnovate.Core.Contracts
{
    public interface IParkingService
    {
        public Task Use();

        public Task Exit();

        public Task Details();

        public Task Enable();

        public Task Disable();

    }
}
