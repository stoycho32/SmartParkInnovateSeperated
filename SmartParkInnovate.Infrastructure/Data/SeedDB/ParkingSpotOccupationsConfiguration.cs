using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartParkInnovate.Infrastructure.Data.Models;

namespace SmartParkInnovate.Infrastructure.Data.SeedDB
{
    internal class ParkingSpotOccupationsConfiguration : IEntityTypeConfiguration<ParkingSpotOccupation>
    {
        public void Configure(EntityTypeBuilder<ParkingSpotOccupation> builder)
        {
            builder.HasKey(c => new { c.ParkingSpotId, c.VehicleId, c.EnterDateTime });
        }
    }
}
