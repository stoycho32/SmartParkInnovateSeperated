using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartParkInnovate.Infrastructure.Data.Models;

namespace SmartParkInnovate.Infrastructure.Data.SeedDB
{
    internal class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            var data = new SeedData();

            builder.HasData(new Worker[]
                {
                     data.Test1Worker,
                    data.Test2Worker,
                     data.Test3Worker
                });
        }
    }
}
