namespace LSOrderManagementAPI.DataModel.Order
{
    public class OrderFilterDataModel:IBaseFilterDataModel
    {
        public DateTime? FromDate { get; set; } = DateTime.Today.AddDays(-30);
        public DateTime? ToDate { get; set; } = DateTime.Today;
        public int CustomerId { get; set; }
        public int Id { get; set; }
        public int Pages { get; set; }
        public int Records { get; set; }
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public string OrderDir { get; set; }
    }
}
