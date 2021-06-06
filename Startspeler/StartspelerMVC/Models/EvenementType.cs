using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class EvenementType
    {
        public int EvenementTypeID { get; set; }
        public string Type { get; set; }

        public ICollection<Evenement> Evenementen { get; set; }
    }
}