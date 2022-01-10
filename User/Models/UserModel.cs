using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Models
{
    // Active record
    internal class UserModel : BaseSerializable
    {
        public string username { get; set; } = "null";
        public string passwordHash { get; set; } = "null";
        public string chucVu { get; set; } = "null"; // "NhanVien" or "Marketing"

        // Business logic
        public bool CheckValidLogin()
        {
            if (username.Length % 2 == 0 
                && passwordHash.Length % 2 == 0)
                    return true;
            return false;
        }

        public void ChangePassword(string password)
        {
            passwordHash = HashPassword(password);
            Update();
        }

        public static string HashPassword(string password)
        {
            char[] carr = password.ToCharArray();
            Array.Reverse(carr);
            return new string(carr);
        }

        // Data access
        public static UserModel GetByUsername(string username)
        {
            return new UserModel()
            {
                username = username,
                passwordHash = "abcd",
                chucVu = "NhanVien"
            };
        }

        public void Insert()
        {
            // insert this instance to database
        }

        public void Update()
        {
            // update current model to database
        }
    }
}
