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
            public const string InvalidVehicleErrorMessage = "Invalid Vehicle";
            public const string VehicleMakeLengthErrorMessage = "Car make must be between 2 and 50 characters long.";
            public const string VehicleModelLengthErrorMessage = "Car model name must be between 3 and 50 characters long.";
            public const string VehicleAlreadyExistsErrorMessage = "Vehicle already exists";
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
            public const string ParkingSpotNotOccupiedErrorMessage = "Parking Spot Is Not Occupied";
            public const string ParkingSpotIsDisabledErrorMessage = "Parking Spot Is Disabled";
            public const string ParkingSpotAlreadyInUseErrorMessage = "Parking Spot Is Already In Use";
            public const string ParkingSpotWasNotUsed = "The Parking Spot Was Not Used And It Cannot Be Exited";
        }

        public static class WorkerErrorMessages
        {
            public const string InvalidWorkerErrorMessage = "Invalid Credentials";
        }

        public static class GeneralErrorMessages
        {
            public const string SomethingUnexpectedOccuredErrorMessage = "Something Unexpected Occured";
        }

    }
}
