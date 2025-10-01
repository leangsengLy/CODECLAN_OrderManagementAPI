using LSOrderManagementAPI.ApiReponse;
using LSOrderManagementAPI.DataModel.Item;
using LSOrderManagementAPI.DataModel.Login;
using LSOrderManagementAPI.DataModel.Order;
using LSOrderManagementAPI.Helper;
using LSOrderManagementAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LSOrderManagementAPI.Controllers
{
    public class LoginRepository : ControllerBase
    {
        protected readonly ApplicationDbContext _db;

        // ✅ Constructor injection
        public LoginRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual async Task<ActionResult> IsSuccessLogin([FromBody] LoginDataModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                {
                    return Ok(new LSApiResponse(LoginHelper.Message.InvalidData).SetDetail("Email or Password are required."));
                }
                var result = await LoginService.IsLoginSuccess(model, _db);
                //if (result) {
                //    var user = await _db.LSLOGINs.FirstOrDefaultAsync(s => s.EMAIL == model.Email);
                //    string type = user.USER_TYPE.ToLower();
                //    if (type == "admin" || type == "staff")
                //    {
                //        var token = _tokenService.GenerateJwtToken(user.ID.ToString(), [type]);
                //        return Ok(new { token,isSuccess = true });
                //    }else return Ok(new LSApiResponse(LoginHelper.Message.NotAllowToAccess).SetDetail());
                //}
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new LSApiResponse(LoginHelper.Message.InterServerError).SetDetail(ex));
            }
        }

        public virtual async Task<ActionResult> Register([FromBody] LoginDataModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password))
                {
                    return Ok(new LSApiResponse(LoginHelper.Message.InvalidData, HttpStatusCode.BadRequest).SetDetail("Email or Password are required."));
                }
                if (_db.LSLOGINs.Any(s => s.EMAIL == model.Email))
                {
                    return Ok(new LSApiResponse(LoginHelper.Message.EmailExisted, HttpStatusCode.BadRequest).SetDetail());
                }
                var result = await LoginService.Register(model, _db);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new LSApiResponse(LoginHelper.Message.InterServerError).SetDetail(ex));
            }
        }
    }
}
