﻿using Microsoft.EntityFrameworkCore;
using SmartParkInnovate.Core.Contracts.AdminServiceContracts;
using SmartParkInnovate.Core.Models.AdminModels.AdminVehicleModels;
using static SmartParkInnovate.Infrastructure.Data.Constants.ErrorMessages.VehicleErrorMessages;
using SmartParkInnovate.Infrastructure.Data.Models;
using SmartParkInnovate.Infrastructure.Repository;

namespace SmartParkInnovate.Core.Services.AdminService
{
    public class AdminVehicleService : IAdminVehicleService
    {
        private readonly IRepository repository;

        public AdminVehicleService(IRepository repository)
        {
            this.repository = repository;
        }


        /// <summary>
        /// Allows the admin to check all the vehicles registered in the application
        /// </summary>
        /// <param name="licensePlate">license plate filter with contains in order to be more flexible</param>
        /// <param name="ownerEmail">the email filter of the owner</param>
        /// <param name="make">The make of the vehicle</param>
        /// <param name="model">The model of the vehicle</param>
        /// <returns></returns>
        public async Task<IEnumerable<AdminVehicleViewModel>> AllVehicles(string? licensePlate, string? ownerEmail, string? make, string? model)
        {
            IEnumerable<AdminVehicleViewModel> vehicles = await this.repository.AllAsReadOnly<Vehicle>()
                .Select(c => new AdminVehicleViewModel()
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    LicensePlate = c.LicensePlate,
                    OwnerEmail = c.Worker.UserName,
                    IsDeleted = c.IsDeleted

                }).ToListAsync();

            if (licensePlate != null)
            {
                vehicles = vehicles.Where(c => c.LicensePlate.Contains(licensePlate)).ToList();
            }

            if (ownerEmail != null)
            {
                vehicles = vehicles.Where(c => c.OwnerEmail.Contains(ownerEmail)).ToList();
            }

            if (make != null)
            {
                vehicles = vehicles.Where(c => c.Make.Contains(make)).ToList();
            }

            if (model != null)
            {
                vehicles = vehicles.Where(c => c.Model.Contains(model)).ToList();
            }

            return vehicles;
        }


        /// <summary>
        /// Provides details about the vehicle
        /// </summary>
        /// <param name="id">the id of the vehicle</param>
        /// <returns>a detailed vehicle model</returns>
        /// <exception cref="ArgumentException">if the vehicle is invalid</exception>
        public async Task<AdminVehicleDetailsModel> Details(int id)
        {
            AdminVehicleDetailsModel? vehicle = await this.repository.AllAsReadOnly<Vehicle>()
                .Where(c => c.Id == id)
                .Select(c => new AdminVehicleDetailsModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    LicensePlate = c.LicensePlate,
                    OwnerEmail = c.Worker.UserName,
                    OwnerFullName = $"{c.Worker.FirstName} {c.Worker.LastName}",
                    OccupationsCount = c.ParkingSpotOccupations.Count(),
                    IsDeleted = c.IsDeleted,
                    DeletedOn = c.DeletedOn

                }).FirstOrDefaultAsync();

            if (vehicle == null)
            {
                throw new ArgumentException(string.Format(InvalidVehicleErrorMessage));
            }

            return vehicle;
        }


        /// <summary>
        /// returns a deleted vehicle
        /// </summary>
        /// <param name="id">the id of the vehicle that should be returned</param>
        /// <exception cref="ArgumentException">if the vehicle is invalid</exception>
        /// <exception cref="InvalidOperationException">is the vehicle was not deleted</exception>
        public async Task ReturnVehicle(int id)
        {
            Vehicle? vehicleToReturn = await this.repository.GetByIdAsync<Vehicle>(id);

            if (vehicleToReturn == null)
            {
                throw new ArgumentException(string.Format(InvalidVehicleErrorMessage));
            }

            if (vehicleToReturn.IsDeleted == false)
            {
                throw new InvalidOperationException(string.Format(VehicleIsNotDeletedErrorMessage));
            }

            vehicleToReturn.IsDeleted = false;
            vehicleToReturn.DeletedOn = null;

            await this.repository.SaveChangesAsync();
        }



        /// <summary>
        /// Removes a selected vehicle
        /// </summary>
        /// <param name="id">vehicle id</param>
        /// <exception cref="ArgumentException">if the vehicle is invalid</exception>
        /// <exception cref="InvalidOperationException">if the vehicle is already deleted</exception>
        public async Task RemoveVehicle(int id)
        {
            Vehicle? vehicleToRemove = await this.repository.GetByIdAsync<Vehicle>(id);

            if (vehicleToRemove == null)
            {
                throw new ArgumentException(string.Format(InvalidVehicleErrorMessage));
            }

            if (vehicleToRemove.IsDeleted == true)
            {
                throw new InvalidOperationException(string.Format(VehicleAlreadyDeletedErrorMessage));
            }

            vehicleToRemove.IsDeleted = true;
            vehicleToRemove.DeletedOn = DateTime.Now;

            await this.repository.SaveChangesAsync();
        }

    }
}
