using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using StartspelerMVC.Models;

namespace StartspelerMVC.Areas.Admin.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
}
