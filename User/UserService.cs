using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Models;

namespace User
{
    internal class UserService
    {
        public static string TryLogin(string username, string passwordHash)
        {
            UserModel user = new UserModel()
            {
                username = username,
                passwordHash = passwordHash
            };

            if (user.CheckValidLogin())
                return "Login succeeded!";
            return "Login failed!";
        }

        public static string ChangePassword(string username, string newPassword)
        {
            UserModel user = new UserModel()
            {
                username = username
            };
            user.ChangePassword(newPassword);
            return "Password changed.";
        }
    }
}
