using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSOrderManagementAPI.Model
{
    [Table("LSLOGIN")]
    public class LSLOGIN
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string EMAIL { get; set; }
        [Required]
        public string PASSWORD { get; set; }
        [Required]
        public string USER_TYPE { get; set; }
        public DateTime DATE_REGISTER { get; set; }
        public DateTime? UPDATED_DATE { get; set; }

    }
}
