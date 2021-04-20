using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class Inschrijving
    {
        public int InschrijvingID { get; set; }
        public int EvenementID { get; set; }

        public int UserID { get; set; }
    }
}