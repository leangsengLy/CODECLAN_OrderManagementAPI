namespace LSOrderManagementAPI.DataModel.Customer
{
    public class CustomerFilterDataModel : IBaseFilterDataModel
    {
        public string Database { get; set; }
        public int Pages { get; set; }
        public int Records { get; set; }
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public string OrderDir { get; set; }
    }
}
