﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class User : IdentityUser
    {
       
        //public int UserID { get; set; }
        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public DateTime Geboortedatum { get; set; }

        public int Pincode { get; set; }

        public string token { get; set; }

        public Boolean Admin { get; set; }

       // public string Email { get; set; }

        public ICollection<Inschrijving> Inschrijvingen { get; set; }

        public ICollection<Drankkaart> Drankkaarten { get; set; }

        public ICollection<Bestelling> Bestellingen { get; set; }
    }
}