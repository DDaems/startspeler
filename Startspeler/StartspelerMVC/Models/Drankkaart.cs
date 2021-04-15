using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class Drankkaart
    {
        public int DrankkaartID { get; set; }

        public int userID { get; set; }

        public int Aantal_Verbruikt { get; set; }

        public int DrankkaartTypeID { get; set; }
    }
}