namespace SmartParkInnovate.Infrastructure.Data.Constants
{
    public static class ErrorMessages
    {
        public const string DepartmentNameLengthErrorMessage = "Department name must be between 3 and 100 characters long.";

        public const string VehicleMakeLengthErrorMessage = "Car make must be between 2 and 50 characters long.";
        public const string VehicleModelLengthErrorMessage = "Car model name must be between 3 and 50 characters long.";

        public const string CommentBodyErrorMessage = "Comment cannot be empty.";
        public const string PostBodyErrorMessage = "Post body cannot be empty.";
    }
}
