using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class Bestellijn
    {
        public int BestellijnID { get; set; }
        public Product Product { get; set; }

        public int Aantal { get; set; }
    }
}