using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartspelerMVC.Models;

namespace StartspelerMVC.Viewmodels
{
    public class OverzichtEvenementenViewModel
    {
        public ICollection<Evenement> LiveEvenementen { get; set; }

        public ICollection<Evenement> AankomendeEvenementen { get; set; }

        public ICollection<Evenement> AfgelopenEvenementen { get; set; }
    }
}