using SmartParkInnovate.Infrastructure.Data.Models;

namespace SmartParkInnovate.Infrastructure.Data.SeedDB
{
    public class SeedData
    {
        public ParkingSpot FirstParkingSpot { get; set; }
        public ParkingSpot SecondParkingSpot { get; set; }
        public ParkingSpot ThirdParkingSpot { get; set; }

        public SeedData()
        {
            this.SeedParkingSpots();
        }

        public void SeedParkingSpots()
        {
            FirstParkingSpot = new ParkingSpot()
            {
                Id = 1

            };

            SecondParkingSpot = new ParkingSpot()
            {
                Id = 2
            };

            ThirdParkingSpot = new ParkingSpot() 
            {
                Id = 3
            };
        }

    }
}
