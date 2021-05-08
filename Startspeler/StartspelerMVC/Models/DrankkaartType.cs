using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartspelerMVC.Models
{
    public class DrankkaartType
    {
        public int DrankkaartTypeID { get; set; }

        
        public int Grootte { get; set; }

        [NotMapped]
        public string Selectnaam => $"{Grootte.ToString()}";

        public ICollection<Drankkaart> Drankkaarten { get; set; }
    }
}