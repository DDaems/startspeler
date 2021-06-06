using StartspelerMVC.Models;
using System.Collections.Generic;

namespace StartspelerMVC.Areas.Admin.Models.Export
{
    public class ProductExcelInfo : List<dynamic>
    {
        public Categorie Categorie { get; set; }
        public string Naam { get; set; }

        public float Prijs { get; set; }

        public int Ijskast { get; set; }
        public int OverigeStock { get; set; }
        public int Totaal { get; set; }

    }
}