using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSOrderManagementAPI.Model
{
    [Table("LSORDER_ITEM")]
    public class LSORDER_ITEM
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {  get; set; }
        public int ORDER_ID {  get; set; }
        public int ITEM_ID { get; set; }
        public int Qty { get; set; }
    }
}
