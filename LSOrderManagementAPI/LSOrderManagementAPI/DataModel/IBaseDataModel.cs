namespace LSOrderManagementAPI.DataModel
{
    public interface IBaseDataModel
    {
         string Username { get; set; }
         string Database { get; set; }
         DateTime DateNow { get; set; }
    }
}
