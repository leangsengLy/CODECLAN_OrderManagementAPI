namespace LSOrderManagementAPI.DataModel.Item
{
    public class ItemFilterDataModel : IBaseFilterDataModel
    {
        public string Database { get; set; }
        public int Pages { get; set; }
        public int Records { get; set; }
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public string OrderDir { get; set; }
    }
}
