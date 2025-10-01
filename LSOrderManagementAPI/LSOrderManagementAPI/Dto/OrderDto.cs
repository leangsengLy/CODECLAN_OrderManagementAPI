using LSOrderManagementAPI.Dto;
using LSOrderManagementAPI.Model;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace LSOrderManagementAPI.Controllers
{
    public class OrderQueryDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEnglishName { get; set; }
        public bool CustomerGender { get; set; }
        public string CustomerEMail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerPhone1 { get; set; }
        public string CustomerAddress { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }

    }
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEnglishName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerPhone1 { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public decimal TotalAmount { get; set; }
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
