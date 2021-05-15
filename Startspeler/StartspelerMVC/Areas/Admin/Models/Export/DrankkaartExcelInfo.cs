using System;
using System.Collections.Generic;

namespace StartspelerMVC.Areas.Admin.Models.Export
{
    public class DrankkaartExcelInfo : List<dynamic>
    {
        public string UserName { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime Aankoopdatum { get; set; }
        public int Aantal_beschikbaar { get; set; }
        public int Grootte { get; set; }
        public string Status { get; set; }
    }
}