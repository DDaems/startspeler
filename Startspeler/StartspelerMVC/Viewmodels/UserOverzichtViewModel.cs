using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Viewmodels
{
    public class UserOverzichtViewModel
    {
        public int DrankkaartID { get; set; } 
        public DateTime Aankoopdatum { get; set; } 
        public int Aantal_beschikbaar { get; set; }

        public string Status { get; set; }

        public int Grootte { get; set; }
    }
}
