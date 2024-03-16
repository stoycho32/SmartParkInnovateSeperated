using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartParkInnovate.Infrastructure.Data.Models;

namespace SmartParkInnovate.Infrastructure.Data.SeedDB
{
    internal class ParkingSpotConfiguration : IEntityTypeConfiguration<ParkingSpot>
    {
        public void Configure(EntityTypeBuilder<ParkingSpot> builder)
        {
            var data = new SeedData();

            builder.HasData(new ParkingSpot[]
                {
                    data.FirstParkingSpot,
                    data.SecondParkingSpot,
                    data.ThirdParkingSpot
                });
        }
    }
}
