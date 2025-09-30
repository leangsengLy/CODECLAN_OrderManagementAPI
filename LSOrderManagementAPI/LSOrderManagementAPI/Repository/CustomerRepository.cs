using LSOrderManagementAPI.ApiReponse;
using LSOrderManagementAPI.DataModel.Customer;
using LSOrderManagementAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LSOrderManagementAPI.Controllers
{
    public class CustomerRepository : ControllerBase
    {
        protected readonly ApplicationDbContext _db;

        // ✅ Constructor injection
        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public virtual async Task<ActionResult> List(CustomerFilterDataModel filter)
        {
            try
            {
                filter.Records = filter.Records > 0 ? filter.Records : 10;
                filter.Pages = filter.Pages > 0 ? filter.Pages : 1;
                var result = await CustomerService.List(filter, _db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(CustomerHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }
        public virtual async Task<ActionResult> Create(CustomerDataModel model)
        {
            try
            {
                var msg = "";
                model.Database = string.IsNullOrEmpty(model.Database) ? LSGlobalHelper.String.Database : model.Database;
                model.Username = string.IsNullOrEmpty(model.Username) ? LSGlobalHelper.String.Username : model.Username;
                if (string.IsNullOrEmpty(model.Name)) msg = "Name";
                if (string.IsNullOrEmpty(model.Email)) msg += ",Email";
                if (string.IsNullOrEmpty(model.Phone)) msg += ",Phone";
                if (!string.IsNullOrEmpty(msg))
                {
                    return Ok(new LSApiResponse(CustomerHelper.Message.InvalidData, HttpStatusCode.InternalServerError).SetDetail($@"There are Field ({msg}) are required!"));
                }
                if (_db.LSCUSTOMERs.Any(s => s.EMAIL == model.Email && s.DB_CODE == model.Database))
                {
                    return Ok(new LSApiResponse(CustomerHelper.Message.EmailExisted, HttpStatusCode.InternalServerError).SetDetail($@"There are Field ({msg}) are required!"));
                }
                var result = await CustomerService.Create(model, _db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(CustomerHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }

        public virtual async Task<ActionResult> Update(CustomerDataModel model)
        {
            try
            {
                var msg = "";
                model.Database = string.IsNullOrEmpty(model.Database) ? LSGlobalHelper.String.Database : model.Database;
                model.Username = string.IsNullOrEmpty(model.Username) ? LSGlobalHelper.String.Username : model.Username;
                if (string.IsNullOrEmpty(model.Name)) msg = "Name";
                if (string.IsNullOrEmpty(model.Email)) msg += ",Email";
                if (string.IsNullOrEmpty(model.Phone)) msg += ",Phone";
                if (!string.IsNullOrEmpty(msg))
                {
                    return Ok(new LSApiResponse(CustomerHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail($@"There are Field ({msg}) are required!"));
                }
                if (_db.LSCUSTOMERs.Any(s => s.EMAIL == model.Email && s.DB_CODE == model.Database))
                {
                    return Ok(new LSApiResponse(CustomerHelper.Message.EmailExisted, HttpStatusCode.InternalServerError).SetDetail());
                }
                var find = _db.LSCUSTOMERs.FirstOrDefault(s => s.ID == model.Id && s.DB_CODE == model.Database);
                if (find == null) return Ok(new LSApiResponse(CustomerHelper.Message.NotFound, HttpStatusCode.BadRequest).SetDetail());
                var result = await CustomerService.Update(model, _db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(CustomerHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }

        public virtual async Task<ActionResult> Delete(int id,string database)
        {
            try
            {
                if (id < 1) return Ok(new LSApiResponse(CustomerHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail("id is required!"));
                var data = _db.LSCUSTOMERs.FirstOrDefault(s => s.ID == id && s.DB_CODE == database);
                if(data==null) return Ok(new LSApiResponse(CustomerHelper.Message.NotFound, HttpStatusCode.BadRequest).SetDetail());
                var result = await CustomerService.Delete(id, database,_db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(CustomerHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }
    }
}
