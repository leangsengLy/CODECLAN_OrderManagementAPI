namespace LSOrderManagementAPI.DataModel
{
    public interface IBaseFilterDataModel
    {
        int Pages { get; set; }
        int Records { get; set; }
        string Search { get; set; }
        string OrderBy { get; set; }
        string OrderDir { get; set; }
    }
}
