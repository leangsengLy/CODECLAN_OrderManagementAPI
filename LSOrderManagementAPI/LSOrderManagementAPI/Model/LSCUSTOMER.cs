using LSOrderManagementAPI.DataModel;
using System.ComponentModel.DataAnnotations;

namespace LSOrderManagementAPI.Model
{
    public class LSCUSTOMER : IBaseDataModel
    {
        public int ID { get; set; }
        [StringLength(30),Required]
        public string Name { get; set; }
        [StringLength(30)]
        public string EnglishName { get; set; }
        public bool Gender { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(15)]
        public string Phone1 { get; set; }
        public int Address { get; set; }
        [StringLength(30),Required]
        public string Username { get; set; }
        [StringLength(30), Required]
        public string Database { get; set; }
        public DateTime DateNow { get; set; }
    }
}
