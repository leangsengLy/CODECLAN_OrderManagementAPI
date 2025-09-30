using LSOrderManagementAPI.Dto;
using System.ComponentModel.DataAnnotations;

namespace LSOrderManagementAPI.Controllers
{
    public class CustomerDto :IBaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Phone1 { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public int RecordCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Database { get; set; }
    }
}
