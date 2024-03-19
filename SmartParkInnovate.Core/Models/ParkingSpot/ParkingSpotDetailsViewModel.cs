﻿using SmartParkInnovate.Core.Models.ParkingSpotOccupationsViewModel;
using SmartParkInnovate.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartParkInnovate.Core.Models.ParkingSpot
{
    public class ParkingSpotDetailsViewModel
    {
        public ParkingSpotDetailsViewModel()
        {
            this.ParkingSpotOccupations = new List<ParkingSpotOccupationViewModel>();
        }

        public int Id { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [Required]
        public bool IsOccupied { get; set; }

        public int? OccupationVehicleId { get; set; }

        public Vehicle? OccupationVehicle { get; set; }

        public ICollection<ParkingSpotOccupationViewModel> ParkingSpotOccupations { get; set; }
    }
}
