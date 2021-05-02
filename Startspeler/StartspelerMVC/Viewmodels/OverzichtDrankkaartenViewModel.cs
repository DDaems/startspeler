using System;
using StartspelerMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Viewmodels
{
    public class OverzichtDrankkaartenViewModel
    {
        /*
        public List<Drankkaart> Drankkaart { get; set; }

        public ICollection<DrankkaartType> drankkaartType { get; set; }

        */

        public string Zoekterm { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }
        public DateTime Aankoopdatum { get; set; }

        public int Aantal_beschikbaar { get; set; }

        public int Groote { get; set; }

        

    }
}
