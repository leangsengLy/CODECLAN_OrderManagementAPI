namespace LSOrderManagementAPI.DataModel.Order
{
    public class OrderFilterDataModel:IBaseFilterDataModel
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int CustomerId { get; set; }
        public int Pages { get; set; }
        public int Records { get; set; }
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public string OrderDir { get; set; }
    }
}
