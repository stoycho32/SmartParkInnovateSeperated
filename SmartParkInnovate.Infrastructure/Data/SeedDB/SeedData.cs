using Microsoft.AspNetCore.Identity;
using SmartParkInnovate.Infrastructure.Data.Models;

namespace SmartParkInnovate.Infrastructure.Data.SeedDB
{
    public class SeedData
    {
        public ParkingSpot FirstParkingSpot { get; set; }
        public ParkingSpot SecondParkingSpot { get; set; }
        public ParkingSpot ThirdParkingSpot { get; set; }
        public ParkingSpot ForthParkingSpot { get; set; }
        public ParkingSpot FifthParkingSpot { get; set; }
        public ParkingSpot SixthParkingSpot { get; set; }
        public Worker Test1Worker { get; set; }
        public Worker Test2Worker { get; set; }
        public Worker Test3Worker { get; set; }

        public SeedData()
        {
            this.SeedParkingSpots();
            this.SeedUsers();
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

            ForthParkingSpot = new ParkingSpot()
            {
                Id = 4
            };

            FifthParkingSpot = new ParkingSpot()
            {
                Id = 5
            };

            SixthParkingSpot = new ParkingSpot()
            {
                Id = 6
            };

        }

        public void SeedUsers()
        {
            var hasher = new PasswordHasher<Worker>();

            Test1Worker = new Worker()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "test1@mail.com",
                NormalizedUserName = "test1@mail.com",
                Email = "test1@mail.com",
                NormalizedEmail = "test1@mail.com"
            };

            Test1Worker.PasswordHash =
                 hasher.HashPassword(Test1Worker, "Test1!");

            Test2Worker = new Worker()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "test2@mail.com",
                NormalizedUserName = "test2@mail.com",
                Email = "test2@mail.com",
                NormalizedEmail = "test2@mail.com"
            };

            Test2Worker.PasswordHash =
                 hasher.HashPassword(Test2Worker, "Test2!");

            Test3Worker = new Worker()
            {
                Id = "cc644110-5a86-4e9f-9664-fde76465c618",
                UserName = "test3@mail.com",
                NormalizedUserName = "test3@mail.com",
                Email = "test3@mail.com",
                NormalizedEmail = "test3@mail.com"
            };

            Test3Worker.PasswordHash =
                 hasher.HashPassword(Test3Worker, "Test3!");
        }
    }
}
