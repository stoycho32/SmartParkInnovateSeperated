using System.Text.RegularExpressions;

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
            public const string VehicleDoesNotBelongToWorker = "You Do Not Have Access To This Vehicle";
            public const string VehicleAlreadyDeletedErrorMessage = "Vehicle Is Already Deleted";
            public const string VehicleIsNotDeletedErrorMessage = "Vehicle Is Not Deleted";
            public const string VehicleAlreadyParkedErrorMessage = "Vehicle Is Already Parked On a Spot";
        }

        public static class CommentErrorMessages
        {
            public const string CommentBodyErrorMessage = "Comment cannot be empty.";
        }

        public static class PostErrorMessages
        {
            public const string PostBodyErrorMessage = "Post body cannot be empty.";
            public const string InvalidPostErrorMessage = "The Chosen Post Is Not Valid";
            public const string PostIsDeletedErrorMessage = "Post Is Deleted";
            public const string PostIsNotDeletedErrorMessage = "Post Is Not Deleted";
        }

        public static class ParkingSpotErrorMessages
        {
            public const string InvalidParkingSpotErrorMessage = "Invalid Parking Spot";
            public const string ParkingSpotNotOccupiedErrorMessage = "Parking Spot Is Not Occupied";
            public const string ParkingSpotIsDisabledErrorMessage = "Parking Spot Is Disabled";
            public const string ParkingSpotAlreadyInUseErrorMessage = "Parking Spot Is Already In Use";
            public const string ParkingSpotWasNotUsed = "The Parking Spot Was Not Used And It Cannot Be Exited";
            public const string ParkingSpotAlreadyEnabledErrorMessage = "Parking Spot Is Already Enabled";
            public const string ParkingSpotAlreadyDisabledErrorMessage = "Parking Spot Is Already Disabled";
        }

        public static class WorkerErrorMessages
        {
            public const string InvalidWorkerErrorMessage = "Invalid Credentials";
            public const string InvalidPasswordErrorMessage = "The password must be at least 6 and at max 100 characters long.";
            public const string PasswordAndConfirmedPasswordDoesNotMatchErrorMessage = "The password and confirmation password do not match.";
            public const string FirstNameCharactersErrorMessage = "First name must be between 2 and 20 characters long";
            public const string LastNameCharactersErrorMessage = "Last name must be between 2 and 30 characters long";

        }

        public static class GeneralErrorMessages
        {
            public const string SomethingUnexpectedOccuredErrorMessage = "Something Unexpected Occured";
        }

    }
}
