using Microsoft.AspNetCore.Mvc.Rendering;
using StartspelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Viewmodels
{
    public class OverzichtProductViewModel
    {
        public string CategorieSearch { get; set; }

        public List<Product> Producten { get; set; }

        public ICollection<Categorie> Categories { get; set; }

        public Bestelling Bestelling { get; set; }

        public float TotalePrijs { get; set; }

        public int Pincode { get; set; }
    }
}