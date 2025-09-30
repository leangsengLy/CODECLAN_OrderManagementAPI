using LSOrderManagementAPI.DataModel.Item;
using LSOrderManagementAPI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace LSOrderManagementAPI.Controllers
{
    public class ItemApiController: ItemRepository
    {
        public ItemApiController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        [HttpPost(ItemHelper.URL.List)]
        public override Task<ActionResult> List(ItemFilterDataModel filter)
        {
            return base.List(filter);
        }

        [HttpPost(ItemHelper.URL.Create)]
        public override Task<ActionResult> Create(ItemDataModel model)
        {
            return base.Create(model);
        }

        [HttpPost(ItemHelper.URL.Update)]
        public override Task<ActionResult> Update(ItemDataModel model)
        {
            return base.Update(model);
        }

        [HttpPost(ItemHelper.URL.Delete)]
        public override Task<ActionResult> Delete(int id,string database)
        {
            return base.Delete(id, database);
        }


    }
}
