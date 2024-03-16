namespace SmartParkInnovate.Infrastructure.Data.Constants
{
    public static class ErrorMessages
    {
        public static class DepartmentErrorMessages
        {
            public const string DepartmentNameLengthErrorMessage = "Department name must be between 3 and 100 characters long.";
        }

        public static class VehicleErrorMessages
        {
            public const string VehicleMakeLengthErrorMessage = "Car make must be between 2 and 50 characters long.";
            public const string VehicleModelLengthErrorMessage = "Car model name must be between 3 and 50 characters long.";
        }

        public static class CommentErrorMessages
        {
            public const string CommentBodyErrorMessage = "Comment cannot be empty.";
        }

        public static class PostErrorMessages
        {
            public const string PostBodyErrorMessage = "Post body cannot be empty.";
        }

        public static class ParkingSpotErrorMessages
        {
            public const string InvalidParkingSpotErrorMessage = "Invalid Parking Spot";

        }
    }
}
