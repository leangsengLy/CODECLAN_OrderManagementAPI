namespace LSOrderManagementAPI.ApiReponse
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public bool IsSuccess { get; set; }
        public string key_translate { get; set; }

        public ApiResponse(string Message = "", string Detail = "", bool IsSuccess = false, string key_translate = "")
        {
            this.Message = Message;
            this.Detail = Detail;
            this.IsSuccess = IsSuccess;
            this.key_translate = key_translate;
        }

        public ApiResponse SetDetail(string Message)
        {
            this.Detail = Message;
            return this;
        }
    }
}
