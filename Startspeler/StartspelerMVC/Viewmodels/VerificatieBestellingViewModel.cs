using StartspelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Viewmodels
{
    public class VerificatieBestellingViewModel
    {
        public string CategorieSearch { get; set; }

        public List<Product> Producten { get; set; }

        public ICollection<Categorie> Categories { get; set; }

        public Bestelling Bestelling { get; set; }

        public float TotalePrijs { get; set; }

        public string Pincode { get; set; }

        public string Errors { get; set; }

        public string userId { get; set; }
    }
}