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
            var list = await _db.LSITEMs.Where(s => s.DB_CODE == filter.Database).ToListAsync();
            if (!string.IsNullOrEmpty(filter.Search))
            {
                var searchText = filter.Search.Trim();
                list = list.Where(s => s.PRODUCT_NAME.Contains(searchText)).ToList();
            }
            var recordCount = list.Count();
            list = list.Skip(filter.Pages - 1).Take(filter.Records).ToList();
            if (!string.IsNullOrEmpty(filter.OrderBy))
            {
                filter.OrderBy += !string.IsNullOrEmpty(filter.OrderDir) ? $@" {filter.OrderDir} " : "";
                list = list.AsQueryable().OrderBy(filter.OrderBy).ToList();
            }
            return list.Select(s => MappingData(s, recordCount)).ToList();
        }
        public static async Task<OrderDto> Create(OrderDataModel model, ApplicationDbContext _db)
        {
            var data = new LSORDER();;
            var orderItem = new List<LSORDER_ITEM>();
            data.DATE = DateTime.Now;
            data.CUS_ID = model.CustomerId;
            _db.LSORDERs.Add(data);
            await _db.SaveChangesAsync();
            foreach(var item in model.ItemIds)
            {
                orderItem.Add(new LSORDER_ITEM()
                {
                    ITEM_ID = item,
                    ORDER_ID = data.ID
                });
            }
            _db.LSORDER_ITEMs.AddRange(orderItem);
            await _db.SaveChangesAsync();
            return MappingData(data);
        }
        public static async Task<OrderDto> Update(OrderDataModel model, ApplicationDbContext _db)
        {
            var data = _db.LSORDERs.FirstOrDefault(s => s.ID == model.Id);
            var orderItem = _db.LSORDER_ITEMs.Where(s => s.ORDER_ID == model.Id).ToList();
            if (orderItem.Count() > 0) _db.LSORDER_ITEMs.RemoveRange(orderItem);
            data.DATE = DateTime.Now;
            data.CUS_ID = model.CustomerId;
            foreach (var item in model.ItemIds)
            {
                orderItem.Add(new LSORDER_ITEM()
                {
                    ITEM_ID = item,
                    ORDER_ID = data.ID
                });
            }
            _db.LSORDER_ITEMs.AddRange(orderItem);
            await _db.SaveChangesAsync();
            return MappingData(data);
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

        private static OrderDto MappingData(LSORDER obj, int recordCount = 1)
        {
            var data = new OrderDto();
            data.Id = obj.ID;
            data.RecordCount = recordCount;
            return data;
        }
    }
}
