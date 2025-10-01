using LSOrderManagementAPI.DataModel.Customer;
using LSOrderManagementAPI.DataModel.Item;
using LSOrderManagementAPI.DataModel.Login;
using LSOrderManagementAPI.DataModel.Order;
using LSOrderManagementAPI.Model;
using LSOrderManagementAPI.Service;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Dynamic.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LSOrderManagementAPI.Controllers
{
    public class LoginService
    {
        public static async Task<LoginDto> Register(LoginDataModel model, ApplicationDbContext _db)
        {
            var hasPw = new UserLoginService();
            var user = new LSLOGIN();
            user.EMAIL = model.Email;
            user.USER_TYPE = model.UserType;
            user.PASSWORD = hasPw.HashPassword(user, model.Password);
            user.DATE_REGISTER = DateTime.Now;
            _db.LSLOGINs.Add(user);
            await _db.SaveChangesAsync();
            return MappingData(user);
        }
        public static async Task<bool> IsLoginSuccess(LoginDataModel model, ApplicationDbContext _db)
        {
            var hasPw = new UserLoginService();
            var find = await _db.LSLOGINs.FirstOrDefaultAsync(s => s.EMAIL == model.Email);
            var isCorrect = false;
            if (find != null) isCorrect = hasPw.VerifyPassword(find, find.PASSWORD, model.Password);
            return isCorrect;
        }
        private static LoginDto MappingData(LSLOGIN obj)
        {
            var data = new LoginDto();
            data.Id = obj.ID;
            data.Email = obj.EMAIL;
            data.Password = obj.PASSWORD;
            data.DateRegister = obj.DATE_REGISTER;
            data.UpdatedDate = obj.UPDATED_DATE;
            return data;
        }
    }
}
