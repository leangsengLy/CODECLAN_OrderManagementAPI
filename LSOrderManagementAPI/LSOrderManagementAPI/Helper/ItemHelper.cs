using LSOrderManagementAPI.ApiReponse;

namespace LSOrderManagementAPI.Helper
{
    public class ItemHelper
    {
        public static class URL
        {
            public const string List = "api/item/list";
            public const string Create = "api/item/create";
            public const string Update = "api/item/update";
            public const string Delete = "api/item/delete";
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
