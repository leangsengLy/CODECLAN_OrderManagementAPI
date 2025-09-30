using LSOrderManagementAPI.DataModel.Customer;
using LSOrderManagementAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Dynamic.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LSOrderManagementAPI.Controllers
{
    public class CustomerService
    {
        public static async Task<List<CustomerDto>> List(CustomerFilterDataModel filter, ApplicationDbContext _db)
        {
            var list = await _db.LSCUSTOMERs.Where(s => s.DB_CODE == filter.Database).ToListAsync();
            if (!string.IsNullOrEmpty(filter.Search))
            {
                var searchText = filter.Search.Trim();
                list = list.Where(s => s.NAME.Contains(searchText) ||
                s.EN_NAME.Contains(searchText) ||
                s.EMAIL.Contains(searchText) ||
                s.PHONE1.Contains(searchText) ||
                s.PHONE.Contains(searchText) 
                ).ToList();
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
        public static async Task<CustomerDto> Create(CustomerDataModel model, ApplicationDbContext _db)
        {
            var data = new LSCUSTOMER();
            data.NAME = model.Name;
            data.EN_NAME = model.EnglishName;
            data.ADDRESS = model.Address;
            data.GENDER = model.Gender;
            data.EMAIL = model.Email;
            data.PHONE = model.Phone;
            data.PHONE1 = model.Phone1;
            data.DB_CODE = model.Database;
            data.CREATED_BY = model.Username;
            data.CREATED_DATE = DateTime.Now;
            _db.LSCUSTOMERs.Add(data);
            await _db.SaveChangesAsync();
            return MappingData(data);
        }
        public static async Task<CustomerDto> Update(CustomerDataModel model, ApplicationDbContext _db)
        {
            var data = _db.LSCUSTOMERs.FirstOrDefault(s => s.ID == model.Id && s.DB_CODE == model.Database);
            data.NAME = model.Name;
            data.EN_NAME = model.EnglishName;
            data.ADDRESS = model.Address;
            data.GENDER = model.Gender;
            data.PHONE = model.Phone;
            data.EMAIL = model.Email;
            data.PHONE1 = model.Phone1;
            data.DB_CODE = model.Database;
            data.UPDATED_BY = model.Username;
            data.UPDATED_DATE = DateTime.Now;
            await _db.SaveChangesAsync();
            return MappingData(data);
        }
        public static async Task<bool> Delete(int id, string database, ApplicationDbContext _db)
        {
            var data = _db.LSCUSTOMERs.FirstOrDefault(s => s.ID == id && s.DB_CODE == database);
            _db.LSCUSTOMERs.Remove(data);
            await _db.SaveChangesAsync();
            return true;
        }

        private static CustomerDto MappingData(LSCUSTOMER obj,int recordCount = 1)
        {
            var data = new CustomerDto();
            data.Id = obj.ID;
            data.Name = obj.NAME;
            data.EnglishName = obj.EN_NAME;
            data.Email = obj.EMAIL;
            data.Phone1 = obj.PHONE;
            data.Phone = obj.PHONE;
            data.RecordCount = recordCount;
            data.Address = obj.ADDRESS;
            data.Gender = obj.GENDER;
            data.CreatedBy = obj.CREATED_BY;
            data.UpdatedBy = obj.UPDATED_BY;
            data.CreatedDate = obj.CREATED_DATE;
            data.UpdatedDate = obj.UPDATED_DATE;
            data.Database = obj.DB_CODE;
            return data;
        }
    }
}
