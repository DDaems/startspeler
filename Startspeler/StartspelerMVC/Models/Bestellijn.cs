using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class Bestellijn
    {
        public int BestellijnID { get; set; }

        public int ProductID { get; set; }

        public int Aantal { get; set; }

        public int BestellingID { get; set; }
    }
}