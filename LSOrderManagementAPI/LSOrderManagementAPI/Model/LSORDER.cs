using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSOrderManagementAPI.Model
{
    [Table("LSORDER")]
    public class LSORDER
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime DATE { get; set; }
        public int CUS_ID { get; set; }

    }
}
