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

        public static string CreateAccount(string username, string password)
        {
            UserModel user = new UserModel()
            {
                username = username,
                passwordHash = UserModel.HashPassword(password)
            };

            try
            {
                user.Insert();
                return "Insert successful!";
            }
            catch (Exception ex)
            {
                return $"Insert failed! Error: {ex.Message}";
            }
        }

        public static string ChangePassword(string username, string newPassword)
        {
            UserModel user = new UserModel()
            {
                username = username
            };

            try
            {
                user.ChangePassword(newPassword);
                return "Password changed.";
            }
            catch (Exception ex)
            {
                return $"Password change failed! Error: {ex.Message}";
            }
        }
    }
}
