using LSOrderManagementAPI.ApiReponse;

namespace LSOrderManagementAPI.Helper
{
    public class OrderHelper
    {
        public static class URL
        {
            public const string List = "api/order/list";
            public const string Create = "api/order/create";
            public const string Update = "api/order/update";
            public const string Delete = "api/order/delete";
        }
        public static class Message
        {
            public static ApiResponse InvalidData => new ApiResponse("Invalid Data", "", false, "invalid_data");
            public static ApiResponse NotFound => new ApiResponse("Data was not found!", "", false, "data_was_not_found");
            public static ApiResponse SomethingWhenWrong => new ApiResponse("Something when wrong.", "", false, "data_was_not_found");
            public static ApiResponse InterServerError => new ApiResponse("Internal Server Error", "", false, "internal_server_error");
        }
    }
}
