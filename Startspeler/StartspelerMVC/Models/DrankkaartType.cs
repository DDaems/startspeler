using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class DrankkaartType
    {
        public int DrankkaartTypeID { get; set; }

        public int Grootte { get; set; }

        public ICollection<Drankkaart> Drankkaarten { get; set; }
    }
}