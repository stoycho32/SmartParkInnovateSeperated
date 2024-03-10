﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Infrastructure.Data.Models;
using System.Reflection.Emit;

namespace SmartParkInnovate.Data
{
    public class ApplicationDbContext : IdentityDbContext<Worker>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingSpot> parkingSpots { get; set; }
        public DbSet<ParkingSpotOccupation> ParkingSpotOccupations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           // builder.Entity<Worker>()
           //     .HasMany(c => c.Vehicles)
           //     .WithOne(c => c.Worker)
           //     .OnDelete(DeleteBehavior.Restrict);
           //
           // builder.Entity<Vehicle>()
           //     .HasOne(c => c.Worker)
           //     .WithMany(c => c.Vehicles)
           //     .OnDelete(DeleteBehavior.Restrict);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);
        }
    }
}