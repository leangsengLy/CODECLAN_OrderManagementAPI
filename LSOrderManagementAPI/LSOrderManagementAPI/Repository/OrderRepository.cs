using LSOrderManagementAPI.ApiReponse;
using LSOrderManagementAPI.DataModel.Item;
using LSOrderManagementAPI.DataModel.Order;
using LSOrderManagementAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LSOrderManagementAPI.Controllers
{
    public class OrderRepository : ControllerBase
    {
        protected readonly ApplicationDbContext _db;

        // ✅ Constructor injection
        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public virtual async Task<ActionResult> List([FromBody] OrderFilterDataModel filter)
        {
            try
            {
                if (filter.FromDate > filter.ToDate)
                {
                    return Ok(new LSApiResponse(OrderHelper.Message.InvalidData).SetDetail($@"From date should be smaller than to date!"));
                }
                var result = await OrderServie.List(filter, _db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(OrderHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }
        public virtual async Task<ActionResult> Create([FromBody] OrderDataModel model)
        {
            try
            {
                if (model.OrderItems == null || model.OrderItems.Count == 0)
                {
                    return Ok(new LSApiResponse(OrderHelper.Message.InvalidData).SetDetail($@"Customer must buy product at least one!"));
                }
                if (!_db.LSITEMs.Any(s => model.OrderItems.Select(s => s.ItemId).Contains(s.ID)))
                {
                    return Ok(new LSApiResponse(OrderHelper.Message.NotFound).SetDetail($@"Some product no available in our stock."));
                }
                if (model.OrderItems.Select(s => s.Qty).Any(s => s <= 0))
                {
                    return Ok(new LSApiResponse(OrderHelper.Message.InvalidData).SetDetail($@"The Qty must be more than 0."));
                }
                if (!_db.LSCUSTOMERs.Any(s => s.ID == model.CustomerId))
                {
                    return Ok(new LSApiResponse(OrderHelper.Message.NotFound).SetDetail($@"Customer not found!"));
                }
                var result = await OrderServie.Create(model, _db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(OrderHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }

        public virtual async Task<ActionResult> Update([FromBody] OrderDataModel model)
        {
            try
            {
                if (model.OrderItems == null || model.OrderItems.Count == 0)
                {
                    return Ok(new LSApiResponse(OrderHelper.Message.InvalidData).SetDetail($@"Customer must buy product at least one!"));
                }
                if (!_db.LSITEMs.Any(s => model.OrderItems.Select(s=>s.ItemId).Contains(s.ID)))
                {
                    return Ok(new LSApiResponse(OrderHelper.Message.NotFound).SetDetail($@"Some product no available in our stock."));
                }
                if (!_db.LSCUSTOMERs.Any(s => s.ID == model.CustomerId))
                {
                    return Ok(new LSApiResponse(OrderHelper.Message.NotFound).SetDetail($@"Customer not found!"));
                }
                if (model.OrderItems.Select(s => s.Qty).Any(s => s <= 0))
                {
                    return Ok(new LSApiResponse(OrderHelper.Message.InvalidData).SetDetail($@"The Qty must be more than 0."));
                }
                var find  = _db.LSORDERs.FirstOrDefault(s => s.ID == model.Id);
                if(find == null)
                {
                    return Ok(new LSApiResponse(OrderHelper.Message.NotFound).SetDetail());
                }
                var result = await OrderServie.Update(model, _db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(OrderHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }

        public virtual async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (id < 1) return Ok(new LSApiResponse(OrderHelper.Message.InvalidData).SetDetail("id is required!"));
                var data  = _db.LSORDERs.FirstOrDefault(s => s.ID == id);
                if (data == null) return Ok(new LSApiResponse(OrderHelper.Message.NotFound).SetDetail());
                var result = await OrderServie.Delete(id, _db);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new LSApiResponse(OrderHelper.Message.InterServerError, HttpStatusCode.InternalServerError).SetDetail(e.Message));
            }
        }
    }
}
