using LSOrderManagementAPI.ApiReponse;
using LSOrderManagementAPI.DataModel.Item;
using LSOrderManagementAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LSOrderManagementAPI.Controllers
{
    public class ItemRepository : ControllerBase
    {
        protected readonly ApplicationDbContext _db;

        // ✅ Constructor injection
        public ItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public virtual async Task<ActionResult> List([FromBody] ItemFilterDataModel filter)
        {
            try
            {
                filter.Pages = filter.Pages > 0 ? filter.Pages : 1;
                filter.Records = filter.Records > 0 ? filter.Records : 10;
                filter.Database = !string.IsNullOrEmpty(filter.Database) ? filter.Database : LSGlobalHelper.String.Database;
                if (string.IsNullOrEmpty(filter.Database))
                {
                    return Ok(new LSApiResponse(ItemHelper.Message.InvalidData).SetDetail("Database is required."));
                }
                var result = await ItemService.List(filter, _db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(ItemHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }
        public virtual async Task<ActionResult> Create([FromBody] ItemDataModel model)
        {
            try
            {
                var msg = "";
                model.Username = string.IsNullOrEmpty(model.Username) ? LSGlobalHelper.String.Username : model.Username;
                if (string.IsNullOrEmpty(model.ProductName)) msg = "Name";
                if (string.IsNullOrEmpty(model.Database)) msg += ",Database";
                if (!string.IsNullOrEmpty(msg))
                {
                    return Ok(new LSApiResponse(ItemHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail($@"There are Field ({msg}) are required!"));
                }
                if (model.Qty < 1 || model.UnitPrice < 1) return Ok(new LSApiResponse(ItemHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail($@"Qty and Price must be bigger than 0"));
                var result = await ItemService.Create(model, _db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(ItemHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }

        public virtual async Task<ActionResult> Update([FromBody] ItemDataModel model)
        {
            try
            {
                var msg = "";
                model.Username = string.IsNullOrEmpty(model.Username) ? LSGlobalHelper.String.Username : model.Username;
                if (string.IsNullOrEmpty(model.ProductName)) msg = "Name";
                if (string.IsNullOrEmpty(model.Database)) msg += ",Database";
                if (!string.IsNullOrEmpty(msg))
                {
                    return Ok(new LSApiResponse(ItemHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail($@"There are Field ({msg}) are required!"));
                }
                if (model.Id < 1) return Ok(new LSApiResponse(ItemHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail("Id is required."));
                if (!_db.LSITEMs.Any(s => s.ID == model.Id && s.DB_CODE == model.Database))
                {
                    return Ok(new LSApiResponse(ItemHelper.Message.NotFound, HttpStatusCode.BadRequest).SetDetail());
                }
                if (model.Qty < 1 || model.UnitPrice < 1) return Ok(new LSApiResponse(ItemHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail($@"Qty and Price must be bigger than 0"));
                var result = await ItemService.Update(model, _db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(ItemHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }

        public virtual async Task<ActionResult> Delete(int id, string database)
        {
            try
            {
                if (id < 1) return Ok(new LSApiResponse(ItemHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail("id is required!"));
                if (string.IsNullOrEmpty(database))
                {
                    return Ok(new LSApiResponse(ItemHelper.Message.InvalidData).SetDetail("Database is required."));
                }
                var data = _db.LSITEMs.FirstOrDefault(s => s.ID == id && s.DB_CODE == database);
                if (data == null) return Ok(new LSApiResponse(ItemHelper.Message.NotFound, HttpStatusCode.BadRequest).SetDetail());
                var result = await ItemService.Delete(id, database, _db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(ItemHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }
    }
}
