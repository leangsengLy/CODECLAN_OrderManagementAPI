using LSOrderManagementAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace LSOrderManagementAPI.Service
{
    public class UserLoginService
    {
        private readonly PasswordHasher<LSLOGIN> _passwordHasher = new PasswordHasher<LSLOGIN>();

        public string HashPassword(LSLOGIN user, string plainPassword)
        {
            return _passwordHasher.HashPassword(user, plainPassword);
        }

        public bool VerifyPassword(LSLOGIN user, string hashedPassword, string inputPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, inputPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
