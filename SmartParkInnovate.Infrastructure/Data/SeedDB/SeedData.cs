using Microsoft.AspNetCore.Identity;
using SmartParkInnovate.Infrastructure.Data.Models;

namespace SmartParkInnovate.Infrastructure.Data.SeedDB
{
    public class SeedData
    {
        public ParkingSpot FirstParkingSpot { get; set; }
        public ParkingSpot SecondParkingSpot { get; set; }
        public ParkingSpot ThirdParkingSpot { get; set; }
        public ParkingSpot FourthParkingSpot { get; set; }
        public ParkingSpot FifthParkingSpot { get; set; }
        public ParkingSpot SixthParkingSpot { get; set; }
        public ParkingSpot SeventhParkingSpot { get; set; }
        public ParkingSpot EighthParkingSpot { get; set; }
        public ParkingSpot NinthParkingSpot { get; set; }
        public ParkingSpot TenthParkingSpot { get; set; }
        public ParkingSpot EleventhParkingSpot { get; set; }
        public ParkingSpot TwelfthParkingSpot { get; set; }
        public Worker Test1Worker { get; set; }
        public Worker Test2Worker { get; set; } 
        public Worker AdminWorker { get; set; }

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

            FourthParkingSpot = new ParkingSpot()
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

            SeventhParkingSpot = new ParkingSpot()
            {
                Id = 7
            };

            EighthParkingSpot = new ParkingSpot()
            {
                Id = 8
            };

            NinthParkingSpot = new ParkingSpot()
            {
                Id = 9
            };

            TenthParkingSpot = new ParkingSpot()
            {
                Id = 10
            };

            EleventhParkingSpot = new ParkingSpot()
            {
                Id = 11
            };

            TwelfthParkingSpot = new ParkingSpot()
            {
                Id = 12
            };
        }

        public void SeedUsers()
        {
            var hasher = new PasswordHasher<Worker>();

            Test1Worker = new Worker()
            {
                Id = "cab58169-f3b4-4d01-b353-cebe9a1ec27c",
                UserName = "test1@mail.com",
                NormalizedUserName = "test1@mail.com",
                Email = "test1@mail.com",
                NormalizedEmail = "test1@mail.com",
                FirstName = "Dimitrichko",
                LastName = "Ivanov"
            };

            Test1Worker.PasswordHash =
                 hasher.HashPassword(Test1Worker, "Test1!");

            Test2Worker = new Worker()
            {
                Id = "8b1d3899-c244-45a9-98a9-aa1ee7d80819",
                UserName = "test2@mail.com",
                NormalizedUserName = "test2@mail.com",
                Email = "test2@mail.com",
                NormalizedEmail = "test2@mail.com",
                FirstName = "Dimitur",
                LastName = "Dimitrov"
            };

            Test2Worker.PasswordHash =
                 hasher.HashPassword(Test2Worker, "Test2!");

            AdminWorker = new Worker()
            {
                Id = "d3d412e3-bdfd-49fc-89e5-7c53a3075673",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com",
                FirstName = "Stoycho",
                LastName = "Karadaliev"
            };

            AdminWorker.PasswordHash =
                 hasher.HashPassword(AdminWorker, "Admin1!");
        }
    }
}
