using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class Bestelling
    {
        public int BestellingID { get; set; }

        public int UserID { get; set; }

        public int Aantal { get; set; }

        public Product Product { get; set; }
    }
}