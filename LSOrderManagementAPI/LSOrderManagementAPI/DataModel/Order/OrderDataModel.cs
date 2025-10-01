namespace LSOrderManagementAPI.DataModel.Order
{
    public class OrderDataModel
    {
        public int Id { get; set; }
        public DateTime DATE { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
    public class OrderItem
    {
        public int ItemIds { get; set; }
        public int Qty { get; set; }
    }
}
