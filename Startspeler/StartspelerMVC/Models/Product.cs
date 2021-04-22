using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Naam { get; set; }

        public float Prijs { get; set; }

        public int Ijskast { get; set; }

        public int OverigeStock { get; set; }

        public int CategorieID { get; set; }

        public Categorie Categorie { get; set; }
    }
}