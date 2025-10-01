using LSOrderManagementAPI.DataModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSOrderManagementAPI.Model
{
    [Table("LSCUSTOMER")]
    public class LSCUSTOMER
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(30),Required]
        public string NAME { get; set; }
        [StringLength(30)]
        public string EN_NAME { get; set; }
        [Required]
        public bool GENDER { get; set; }
        [StringLength(100)]
        public string EMAIL { get; set; }
        [StringLength(15),Required]
        public string PHONE { get; set; }
        [StringLength(15)]
        public string PHONE1 { get; set; }
        public string ADDRESS { get; set; }
        [StringLength(30),Required]
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        [StringLength(30), Required]
        public string DB_CODE { get; set; }
    
    }
}
