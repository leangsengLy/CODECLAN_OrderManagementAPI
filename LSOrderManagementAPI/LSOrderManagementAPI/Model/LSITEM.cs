using LSOrderManagementAPI.DataModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSOrderManagementAPI.Model
{
    public class LSITEM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public int QTY { get; set; }
        public decimal UNIT_PRICE { get; set; }
        public decimal SUB_TOTAL { get; set; }
        [StringLength(30), Required]
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        [StringLength(30), Required]
        public string DB_CODE { get; set; }
    }
}
