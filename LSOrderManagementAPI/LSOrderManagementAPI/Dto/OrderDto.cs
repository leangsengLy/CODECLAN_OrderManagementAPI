using LSOrderManagementAPI.Dto;
using System.ComponentModel.DataAnnotations;

namespace LSOrderManagementAPI.Controllers
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEngllishName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerPhone1 { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public int RecordCount { get; set; }
        public List<Product> products { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}
