using LSOrderManagementAPI.DataModel.Item;
using LSOrderManagementAPI.DataModel.Login;
using LSOrderManagementAPI.Helper;
using LSOrderManagementAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace LSOrderManagementAPI.Controllers
{
    [ApiController]
    public class LoginApiController : LoginRepository
    {
        public LoginApiController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        [HttpPost(LoginHelper.URL.IsLoginSuccess)]
        public override Task<ActionResult> IsSuccessLogin(LoginDataModel model)
        {
            return base.IsSuccessLogin(model);
        }

        [HttpPost(LoginHelper.URL.Register)]
        public override Task<ActionResult> Register(LoginDataModel model)
        {
            return base.Register(model);
        }
    }
}
