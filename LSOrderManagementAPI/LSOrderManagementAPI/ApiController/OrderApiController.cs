using LSOrderManagementAPI.DataModel.Order;
using LSOrderManagementAPI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace LSOrderManagementAPI.Controllers
{
    public class OrderApiController : OrderRepository
    {
        public OrderApiController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        [HttpPost(OrderHelper.URL.List)]
        public override Task<ActionResult> List(OrderFilterDataModel filter)
        {
            return base.List(filter);
        }

        [HttpPost(OrderHelper.URL.Create)]
        public override Task<ActionResult> Create(OrderDataModel model)
        {
            return base.Create(model);
        }

        [HttpPost(OrderHelper.URL.Update)]
        public override Task<ActionResult> Update(OrderDataModel model)
        {
            return base.Update(model);
        }

        [HttpPost(OrderHelper.URL.Delete)]
        public override Task<ActionResult> Delete(int id)
        {
            return base.Delete(id);
        }


    }
}
