using System.ComponentModel.DataAnnotations;

namespace LSOrderManagementAPI.DataModel.Customer
{
    public class CustomerDataModel : IBaseDataModel
    {
        public int Id { get; set; }
        [StringLength(30), Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [StringLength(30)]
        public string EnglishName { get; set; }
        public bool Gender { get; set; }
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [StringLength(15), Required(ErrorMessage = "Email is required.")]
        public string Phone { get; set; }
        [StringLength(15)]
        public string Phone1 { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Database { get; set; }
        public DateTime DateNow { get; set; }
    }
}
