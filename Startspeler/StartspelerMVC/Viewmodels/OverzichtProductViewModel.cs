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

        public string Zoekstring { get; set; }

        public Categorie Categorie { get; set; }
    }
}