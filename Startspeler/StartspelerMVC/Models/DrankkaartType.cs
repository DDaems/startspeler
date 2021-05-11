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

        //[ForeignKey("DrankkaartID")]
        //Drankkaart Drankkaart { get; set; }virtual
        //public Drankkaart Drankkaart { get; set; }
        public ICollection<Drankkaart> Drankkaarten { get; set; }

        [Range(1, 1000, ErrorMessage = "Waarde moet realistisch positief zijn.")]
        public int Grootte { get; set; }

        [NotMapped]
        public string Selectnaam => $"{Grootte.ToString()}";
    }
}