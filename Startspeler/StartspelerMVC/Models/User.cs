using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class User : IdentityUser
    {
        //[Key]
        //public int UserID { get; set; }

        [Required]
        [PersonalData]
        public string Voornaam { get; set; }
        [Required]
        [PersonalData]
        public string Achternaam { get; set; }
        [Required]
        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }
        //We gebruiken password veld van Identity
        //public int Pincode { get; set; }

        //public string token { get; set; }

        //public Boolean Admin { get; set; }

       // public string Email { get; set; }

        public ICollection<Inschrijving> Inschrijvingen { get; set; }

        public ICollection<Drankkaart> Drankkaarten { get; set; }

        public ICollection<Bestelling> Bestellingen { get; set; }
    }
}