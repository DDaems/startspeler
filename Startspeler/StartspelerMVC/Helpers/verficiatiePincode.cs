using Microsoft.AspNetCore.Identity;
using StartspelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Helpers
{
    public static class verficiatiePincode
    {
        // verificatie functie
        public static async Task<int> verify(User u, UserManager<User> _userManager, string pincode)
        {
            int succes = 0;

            if (u != null && !string.IsNullOrEmpty(pincode))
            {
                string hash = u.PasswordHash;
                succes = (int)_userManager.PasswordHasher.VerifyHashedPassword(u, hash, pincode);
            }

            if (succes > 0) return 1;
            return 0;
        }
    }
}
