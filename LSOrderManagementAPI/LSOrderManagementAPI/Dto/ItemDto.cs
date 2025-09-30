using LSOrderManagementAPI.Dto;
using System.ComponentModel.DataAnnotations;

namespace LSOrderManagementAPI.Controllers
{
    public class ItemDto:IBaseDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public string CreatedBy { get; set; }
        public int RecordCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Database { get; set; }
    }
}
