using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    
    public class Drankkaart
    {
        public int DrankkaartID { get; set; }

        //public int userID { get; set; }

        public int Aantal_beschikbaar { get; set; }

        public string Status { get; set; }

        public DateTime Aankoopdatum { get; set; }

        public int DrankkaartTypeID { get; set; }
    }
}