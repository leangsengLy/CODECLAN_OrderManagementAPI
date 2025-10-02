namespace LSOrderManagementAPI.DataModel.Order
{
    public class OrderFilterDataModel
    {
        public DateTime? FromDate { get; set; } = DateTime.Today.AddDays(-30);
        public DateTime? ToDate { get; set; } = DateTime.Today;
        public int CustomerId { get; set; }
        public int Id { get; set; }
    }
}
