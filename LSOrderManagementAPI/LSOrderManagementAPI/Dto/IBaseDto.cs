namespace LSOrderManagementAPI.Dto
{
    public interface IBaseDto
    {
        string CreatedBy { get; set; }
        int RecordCount { get; set; }
        DateTime CreatedDate { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string Database { get; set; }
    }
}
