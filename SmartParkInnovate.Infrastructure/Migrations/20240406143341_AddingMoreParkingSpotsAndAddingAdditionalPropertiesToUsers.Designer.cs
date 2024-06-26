﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartParkInnovate.Data;

#nullable disable

namespace SmartParkInnovate.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240406143341_AddingMoreParkingSpotsAndAddingAdditionalPropertiesToUsers")]
    partial class AddingMoreParkingSpotsAndAddingAdditionalPropertiesToUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.ParkingSpot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ParkingSpots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsEnabled = true,
                            IsOccupied = false
                        },
                        new
                        {
                            Id = 2,
                            IsEnabled = true,
                            IsOccupied = false
                        },
                        new
                        {
                            Id = 3,
                            IsEnabled = true,
                            IsOccupied = false
                        },
                        new
                        {
                            Id = 4,
                            IsEnabled = true,
                            IsOccupied = false
                        },
                        new
                        {
                            Id = 5,
                            IsEnabled = true,
                            IsOccupied = false
                        },
                        new
                        {
                            Id = 6,
                            IsEnabled = true,
                            IsOccupied = false
                        },
                        new
                        {
                            Id = 7,
                            IsEnabled = true,
                            IsOccupied = false
                        },
                        new
                        {
                            Id = 8,
                            IsEnabled = true,
                            IsOccupied = false
                        },
                        new
                        {
                            Id = 9,
                            IsEnabled = true,
                            IsOccupied = false
                        },
                        new
                        {
                            Id = 10,
                            IsEnabled = true,
                            IsOccupied = false
                        },
                        new
                        {
                            Id = 11,
                            IsEnabled = true,
                            IsOccupied = false
                        },
                        new
                        {
                            Id = 12,
                            IsEnabled = true,
                            IsOccupied = false
                        });
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.ParkingSpotOccupation", b =>
                {
                    b.Property<int>("ParkingSpotId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnterDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExitDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ParkingSpotId", "VehicleId", "EnterDateTime");

                    b.HasIndex("VehicleId");

                    b.ToTable("ParkingSpotOccupations");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PostBody")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.PostComment", b =>
                {
                    b.Property<string>("WorkerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentBody")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkerId", "PostId", "CommentDate");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.PostLike", b =>
                {
                    b.Property<string>("WorkerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("WorkerId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostLikes");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WorkerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.Worker", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "cab58169-f3b4-4d01-b353-cebe9a1ec27c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "32fcdfda-676f-4fba-b6df-e8e714404543",
                            Email = "test1@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Dimitrichko",
                            LastName = "Ivanov",
                            LockoutEnabled = false,
                            NormalizedEmail = "test1@mail.com",
                            NormalizedUserName = "test1@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEJR1wQugqxjBzE4noVN9dVVXYwnGz073KIUc52NF754vQJggI1ZZc8yJxi/dSkCwgA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6a56f76b-c2f9-4f7f-b45f-8aa7bcf2789c",
                            TwoFactorEnabled = false,
                            UserName = "test1@mail.com"
                        },
                        new
                        {
                            Id = "8b1d3899-c244-45a9-98a9-aa1ee7d80819",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "32a32bda-d22b-4308-bc37-3c82c5dcc8c2",
                            Email = "test2@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Dimitur",
                            LastName = "Dimitrov",
                            LockoutEnabled = false,
                            NormalizedEmail = "test2@mail.com",
                            NormalizedUserName = "test2@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEMoZPXuIu5fJgWjtwRv6QBQbo+cVTbqw5AX15MJrKH85qNtTrpLlJo2fMhjTZZAa6g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5afc146f-81a7-4808-aee4-c1f01af1fa11",
                            TwoFactorEnabled = false,
                            UserName = "test2@mail.com"
                        },
                        new
                        {
                            Id = "d3d412e3-bdfd-49fc-89e5-7c53a3075673",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ff814433-4aac-4ce5-bb36-d52963cb85ff",
                            Email = "test3@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Stoycho",
                            LastName = "Karadaliev",
                            LockoutEnabled = false,
                            NormalizedEmail = "test3@mail.com",
                            NormalizedUserName = "test3@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEPfnoRBgv+h4jQXAhhKvKEUqWtaYBW1O0ggngc/smh/1IyOr0SlKj1qKhs+17f7MjQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "033b52e2-669d-4d25-a2bc-e7e286f2956f",
                            TwoFactorEnabled = false,
                            UserName = "test3@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.ParkingSpotOccupation", b =>
                {
                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.ParkingSpot", "ParkingSpot")
                        .WithMany("ParkingSpotOccupations")
                        .HasForeignKey("ParkingSpotId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.Vehicle", "Vehicle")
                        .WithMany("ParkingSpotOccupations")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ParkingSpot");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.Post", b =>
                {
                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.Worker", "Worker")
                        .WithMany("Posts")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.PostComment", b =>
                {
                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.Worker", "Worker")
                        .WithMany("Comments")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.PostLike", b =>
                {
                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.Worker", "Worker")
                        .WithMany("Likes")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.HasOne("SmartParkInnovate.Infrastructure.Data.Models.Worker", "Worker")
                        .WithMany("Vehicles")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.ParkingSpot", b =>
                {
                    b.Navigation("ParkingSpotOccupations");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.Navigation("ParkingSpotOccupations");
                });

            modelBuilder.Entity("SmartParkInnovate.Infrastructure.Data.Models.Worker", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Posts");

                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
