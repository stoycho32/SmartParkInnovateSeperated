namespace SmartParkInnovate.Infrastructure.Data.Constants
{
    public static class DataConstants
    {
        public static class DepartmentDataConstants
        {
            public const int DepartmentNameMinLength = 3;
            public const int DepartmentNameMaxLength = 100;
        }


        public static class VehicleDataConstants
        {
            public const int VehicleMakeMinLength = 2;
            public const int VehicleMakeMaxLength = 50;

            public const int VehicleModelMinLength = 2;
            public const int VehicleModelMaxLength = 50;
        }

        public static class CommentDataConstants
        {
            public const int CommentBodyMaxValue = int.MaxValue;
            public const int CommentBodyMinValue = 1;
        }

        public static class PostDataConstants
        {
            public const int PostBodyMaxValue = int.MaxValue;
            public const int PostBodyMinValue = 1;
        }
    }
}
