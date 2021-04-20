using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class Categorie
    {
        public int CategorieID { get; set; }

        public int Naam { get; set; }

        public ICollection<Product> Producten { get; set; }
    }
}