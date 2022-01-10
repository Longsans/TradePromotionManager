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
        public static void TryLogin(string username, string passwordHash)
        {
            UserModel user = new UserModel()
            {
                username = username,
                passwordHash = passwordHash
            };

            if (user.CheckValidLogin())
                PostToConsole("Login success!");
            PostToConsole("Login failed!");
        }

        public static void CreateAccount(string username, string password)
        {
            UserModel user = new UserModel()
            {
                username = username,
                passwordHash = UserModel.HashPassword(password)
            };

            try
            {
                user.Insert();
                PostToConsole("Insert successful!");
            }
            catch (Exception ex)
            {
                PostToConsole($"Insert failed! Error: {ex.Message}");
            }
        }

        public static void ChangePassword(string username, string newPassword)
        {
            UserModel user = new UserModel()
            {
                username = username
            };

            try
            {
                user.ChangePassword(newPassword);
                PostToConsole("Password changed.");
            }
            catch (Exception ex)
            {
                PostToConsole($"Password change failed! Error: {ex.Message}");
            }
        }

        public static void PostToConsole(string message)
        {
            Console.WriteLine($"[{MessageBus.MessageBus.UserService}]: \"{message}\"");
        }
    }
}
