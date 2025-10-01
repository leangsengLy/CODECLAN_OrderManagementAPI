using System.ComponentModel.DataAnnotations;

namespace LSOrderManagementAPI.DataModel.Login
{
    public class LoginDataModel
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Email { get; set; }
        [Required, StringLength(30)]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
  
}
