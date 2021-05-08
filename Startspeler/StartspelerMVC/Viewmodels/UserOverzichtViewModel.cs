using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Viewmodels
{
    public class UserOverzichtViewModel
    {
        public int DrankkaartID { get; set; } 
        public DateTime Aankoopdatum { get; set; }

        [Display(Name = "# /")]
        public int Aantal_beschikbaar { get; set; }

        [Display(Name = "totaal")]
        public int Grootte { get; set; }

        [NotMapped]
        [Display(Name = "verbruikt/beschikbaar")]
        public string SamengesteldeKolom => $"{Aantal_beschikbaar.ToString()}/{Grootte.ToString()}";

        public string Status { get; set; }

        
    }
}
