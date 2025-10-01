using LSOrderManagementAPI.DataModel.Customer;
using LSOrderManagementAPI.DataModel.Item;
using LSOrderManagementAPI.DataModel.Order;
using LSOrderManagementAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Dynamic.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LSOrderManagementAPI.Controllers
{
    public class OrderServie
    {
        public static async Task<List<OrderDto>> List(OrderFilterDataModel filter, ApplicationDbContext _db)
        {
            string where = "WHERE 1 = 1 ";
            if (filter.CustomerId > 0) where += $@" AND CUS.ID ={filter.CustomerId} ";
            if (filter.Id > 0) where += $@" AND ORD.ID ={filter.Id} ";
            where += $@" AND  CAST(ORD.DATE as DATE) BETWEEN '{filter.FromDate}' AND  '{filter.ToDate}' ";
            string query = $@" 
                        SELECT 
                        ORD.ID Id,
                        ORD.DATE Date,
                        CUS.ID CustomerId,
                        CUS.NAME CustomerName,
                        CUS.EN_NAME CustomerEnglishName,
                        CUS.GENDER CustomerGender,
                        CUS.EMAIL CustomerEMail,
                        CUS.PHONE CustomerPhone,
                        CUS.PHONE1 CustomerPhone1,
                        CUS.ADDRESS CustomerAddress,
                        ITM.PRODUCT_NAME ProductName,
                        ORD_ITEM.QTY Qty,
                        ITM.UNIT_PRICE UnitPrice,
                        (ITM.UNIT_PRICE * ORD_ITEM.QTY) SubTotal
                         FROM LSORDER ORD
                        INNER JOIN LSCUSTOMER CUS ON CUS.ID = ORD.CUS_ID
                        LEFT JOIN LSORDER_ITEM ORD_ITEM ON ORD_ITEM.ORDER_ID = ORD.ID
                        INNER JOIN LSITEM ITM ON ITM.ID = ORD_ITEM.ITEM_ID {where} ";
            var result = await _db.Set<OrderQueryDto>().FromSqlRaw(query).ToListAsync();
            var res = result.GroupBy(s => s.Id).Select(s =>
            {
                var order = s.FirstOrDefault();
                var dataList = s;
                return new OrderDto()
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    CustomerName = order.CustomerName,
                    CustomerEnglishName = order.CustomerEnglishName,
                    Gender = order.CustomerGender,
                    CustomerPhone = order.CustomerPhone,
                    CustomerPhone1 = order.CustomerPhone1,
                    CustomerEmail = order.CustomerEMail,
                    Date = order.Date,
                    TotalAmount = s.Sum(s => s.SubTotal),
                    products = s.Select(pro => new Product()
                    {
                        Id = pro.Id,
                        Name = pro.ProductName,
                        Qty = pro.Qty,
                        UnitPrice = pro.UnitPrice,
                        SubTotal = pro.SubTotal
                    }).ToList()

                };
            }).ToList();
            return res;
        }
        public static async Task<OrderDto> Create(OrderDataModel model, ApplicationDbContext _db)
        {
            var data = new LSORDER(); ;
            var orderItem = new List<LSORDER_ITEM>();
            data.DATE = DateTime.Now;
            data.CUS_ID = model.CustomerId;
            _db.LSORDERs.Add(data);
            await _db.SaveChangesAsync();
            foreach (var item in model.OrderItems)
            {
                orderItem.Add(new LSORDER_ITEM()
                {
                    ITEM_ID = item.ItemIds,
                    Qty = item.Qty,
                    ORDER_ID = data.ID
                });
            }
            _db.LSORDER_ITEMs.AddRange(orderItem);
            await _db.SaveChangesAsync();
            var findById = await List(new OrderFilterDataModel() { Id = data.ID }, _db);
            return findById.First();
        }
        public static async Task<OrderDto> Update(OrderDataModel model, ApplicationDbContext _db)
        {
            var data = _db.LSORDERs.FirstOrDefault(s => s.ID == model.Id);
            var orderItem = _db.LSORDER_ITEMs.Where(s => s.ORDER_ID == model.Id).ToList();
            if (orderItem.Count() > 0)
            {
                _db.LSORDER_ITEMs.RemoveRange(orderItem);
                _db.SaveChanges();
            }
            data.DATE = DateTime.Now;
            var addNew =new  List<LSORDER_ITEM>();
            foreach (var item in model.OrderItems)
            {
                addNew.Add(new LSORDER_ITEM()
                {
                    ITEM_ID = item.ItemIds,
                    Qty = item.Qty,
                    ORDER_ID = data.ID
                });
            }
            _db.LSORDER_ITEMs.AddRange(addNew);
            await _db.SaveChangesAsync();
            var findById = await List(new OrderFilterDataModel() { Id = data.ID }, _db);
            return findById.First();
        }
        public static async Task<bool> Delete(int id, ApplicationDbContext _db)
        {
            var data = _db.LSORDERs.FirstOrDefault(s => s.ID == id);
            var findItem = _db.LSORDER_ITEMs.Where(s => s.ORDER_ID == id);
            if (findItem.Count() > 0) _db.LSORDER_ITEMs.RemoveRange(findItem);
            _db.LSORDERs.Remove(data);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
