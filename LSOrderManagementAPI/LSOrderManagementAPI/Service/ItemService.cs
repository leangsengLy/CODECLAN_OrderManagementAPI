using LSOrderManagementAPI.DataModel.Customer;
using LSOrderManagementAPI.DataModel.Item;
using LSOrderManagementAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Dynamic.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LSOrderManagementAPI.Controllers
{
    public class ItemService
    {
        public static async Task<List<ItemDto>> List(ItemFilterDataModel filter, ApplicationDbContext _db)
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
            return list.Select(s=> MappingData(s, recordCount)).ToList();
        }
        public static async Task<ItemDto> Create(ItemDataModel model, ApplicationDbContext _db)
        {
            var data = new LSITEM();
            data.PRODUCT_NAME = model.ProductName;
            data.QTY = model.Qty;
            data.UNIT_PRICE = model.UnitPrice;
            data.SUB_TOTAL = model.Qty * model.UnitPrice;
            data.DB_CODE = model.Database;
            data.CREATED_BY = model.Username;
            data.CREATED_DATE = DateTime.Now;
            _db.LSITEMs.Add(data);
            _db.SaveChanges();
            return MappingData(data);
        }
        public static async Task<ItemDto> Update(ItemDataModel model, ApplicationDbContext _db)
        {
            var data = _db.LSITEMs.FirstOrDefault(s => s.ID == model.Id && s.DB_CODE == model.Database);
            data.PRODUCT_NAME = model.ProductName;
            data.QTY = model.Qty;
            data.UNIT_PRICE = model.UnitPrice;
            data.SUB_TOTAL = model.Qty * model.UnitPrice;
            data.DB_CODE = model.Database;
            data.UPDATED_BY = model.Username;
            data.UPDATED_DATE = DateTime.Now;
            await _db.SaveChangesAsync();
            return MappingData(data);
        }
        public static async Task<bool> Delete(int id, string database, ApplicationDbContext _db)
        {
            var data = _db.LSITEMs.FirstOrDefault(s => s.ID == id && s.DB_CODE == database);
            _db.LSITEMs.Remove(data);
            await _db.SaveChangesAsync();
            return true;
        }

        private static ItemDto MappingData(LSITEM obj,int recordCount = 1)
        {
            var data = new ItemDto();
            data.Id = obj.ID;
            data.ProductName = obj.PRODUCT_NAME;
            data.Qty = obj.QTY;
            data.UnitPrice = obj.UNIT_PRICE;
            data.Total = obj.SUB_TOTAL;
            data.CreatedBy = obj.CREATED_BY;
            data.UpdatedDate = obj.UPDATED_DATE;
            data.UpdatedBy = obj.UPDATED_BY;
            data.CreatedDate = obj.CREATED_DATE;
            data.Database = obj.DB_CODE;
            data.RecordCount = recordCount;
            return data;
        }
    }
}
