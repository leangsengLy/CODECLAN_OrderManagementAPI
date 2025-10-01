using LSOrderManagementAPI.DataModel.Customer;
using LSOrderManagementAPI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace LSOrderManagementAPI.Controllers
{
    public class CustomerApiController: CustomerRepository
    {
        public CustomerApiController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        [HttpPost(CustomerHelper.URL.List)]
        public override Task<ActionResult> List(CustomerFilterDataModel filter)
        {
            return base.List(filter);
        }

        [HttpPost(CustomerHelper.URL.Create)]
        public override Task<ActionResult> Create(CustomerDataModel model)
        {
            return base.Create(model);
        }

        [HttpPost(CustomerHelper.URL.Update)]
        public override Task<ActionResult> Update(CustomerDataModel model)
        {
            return base.Update(model);
        }

        [HttpGet(CustomerHelper.URL.Delete)]
        public override Task<ActionResult> Delete(int id,string database)
        {
            return base.Delete(id, database);
        }


    }
}
