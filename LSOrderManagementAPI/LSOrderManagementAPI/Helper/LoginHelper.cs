using LSOrderManagementAPI.ApiReponse;

namespace LSOrderManagementAPI.Helper
{
    public class LoginHelper
    {
        public static class URL
        {
            public const string Register = "api/login/register";
            public const string IsLoginSuccess = "api/login/is_login_success";
        }
        public static class Message
        {
            public static ApiResponse InvalidData => new ApiResponse("Invalid Data", "", false, "invalid_data");
            public static ApiResponse NotAllowToAccess => new ApiResponse("we not allow you to access our api", "", false, "invalid_data");
            public static ApiResponse NotFound => new ApiResponse("Data was not found!", "", false, "data_was_not_found");
            public static ApiResponse SomethingWhenWrong => new ApiResponse("Something when wrong.", "", false, "data_was_not_found");
            public static ApiResponse InterServerError => new ApiResponse("Internal Server Error", "", false, "internal_server_error");
            public static ApiResponse EmailExisted => new ApiResponse("Email already existed.", "", false, "internal_server_error");
        }
    }
}
