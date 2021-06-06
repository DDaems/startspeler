using StartspelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Viewmodels
{
    public class DetailsEvenementViewModel
    {
        public Evenement GeselecteerdEvenement { get; set; }

        public ICollection<User> GereserveerdeUsers { get; set; }
    }
}