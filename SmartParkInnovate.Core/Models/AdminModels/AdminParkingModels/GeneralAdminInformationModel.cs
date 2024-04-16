namespace SmartParkInnovate.Core.Models.AdminModels.AdminParkingModels
{
    public class GeneralAdminInformationModel
    {
        public int FreeParkingSpots { get; set; }

        public int OccupiedParkingSpots { get; set; }

        public int TotalParkingSpots { get; set; }

        public int SpotsOccupiedForToday { get; set; }

        public int SpotsOccupiedForYesterday { get; set; }
    }
}
