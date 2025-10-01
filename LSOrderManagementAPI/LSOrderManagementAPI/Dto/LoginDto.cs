using LSOrderManagementAPI.Dto;
using LSOrderManagementAPI.Model;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace LSOrderManagementAPI.Controllers
{
    public class LoginDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
    
}
