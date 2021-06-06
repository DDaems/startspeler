using StartspelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Areas.Admin.Models
{
    public class GebruikerModel
    {
        public User user { get; set; }
        public IEnumerable<User> Gebruikers { get; set; }
        public GebruikerModel()
        {
            
        }
    }
}
