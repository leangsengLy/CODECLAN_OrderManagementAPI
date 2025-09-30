using System.Net;

namespace LSOrderManagementAPI.ApiReponse
{
    public class LSApiResponse
    {
        public ApiResponse apiResponse { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public LSApiResponse(ApiResponse apiResponse, HttpStatusCode statusCode)
        {
            this.apiResponse = apiResponse;
            this.StatusCode = statusCode;
        }

        public LSApiResponse SetDetail(dynamic Message)
        {
            this.apiResponse.Detail = Message;
            return this;

        }
        public LSApiResponse SetDetail(string Message = "")
        {
            this.apiResponse.Detail = Message;
            return this;

        }
    }
}
