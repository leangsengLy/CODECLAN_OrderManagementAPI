using System.ComponentModel.DataAnnotations;

namespace LSOrderManagementAPI.DataModel.Item
{
    public class ItemDataModel:IBaseDataModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Product name is required!")]
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public string Username { get; set; }
        public string Database { get; set; }
        public DateTime DateNow { get; set; }
    }
}
