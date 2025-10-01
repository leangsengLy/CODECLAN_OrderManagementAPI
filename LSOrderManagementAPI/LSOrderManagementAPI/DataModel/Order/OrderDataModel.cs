namespace LSOrderManagementAPI.DataModel.Order
{
    public class OrderDataModel
    {
        public int Id { get; set; }
        public DateTime DATE { get; set; }
        public int CustomerId { get; set; }
        public List<int> ItemIds { get; set; }
    }
}
