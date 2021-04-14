using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class Evenement
    {
        public int EvenementID { get; set; }
        public string Titel { get; set; }

        public DateTime Startdatum { get; set; }

        public string Beschrijving { get; set; }

        public float Kostprijs { get; set; }

        public int Max_Deelnemers { get; set; }

        public DateTime Einddatum { get; set; }

        public int EvenementTypeID { get; set; }

        public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}