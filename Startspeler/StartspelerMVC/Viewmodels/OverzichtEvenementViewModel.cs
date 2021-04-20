using StartspelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Viewmodels
{
    public class OverzichtEvenementViewModel
    {
        public ICollection<Evenement> LiveEvenementen { get; set; }

        public ICollection<Evenement> AankomendeEvenementen { get; set; }

        public ICollection<Evenement> AfgelopenEvenementen { get; set; }
    }
}