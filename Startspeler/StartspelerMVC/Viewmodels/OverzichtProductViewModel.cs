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
        public ICollection<Product> Producten { get; set; }

        public int Zoekfilter { get; set; }

        public ICollection<Categorie> Categories { get; set; }
    }
}