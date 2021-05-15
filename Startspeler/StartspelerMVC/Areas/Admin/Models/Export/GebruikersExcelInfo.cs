using System;
using System.Collections.Generic;

namespace StartspelerMVC.Areas.Admin.Models.Export
{
    internal class GebruikersExcelInfo : List<dynamic>
    {
        public string UserName { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set;  }
        public DateTime Geboortedatum { get; set; }
        public GebruikersExcelInfo()
        {

        }
        public GebruikersExcelInfo(string alias, string voornaam, string naam, string email, DateTime geboortedatum)
        {
            UserName = alias;
            Voornaam = voornaam;
            Achternaam = naam;
            Email = email;
            Geboortedatum = geboortedatum;
        }

        public override bool Equals(object obj)
        {
            return obj is GebruikersExcelInfo other &&
                   UserName == other.UserName &&
                   Voornaam == other.Voornaam &&
                   Achternaam == other.Achternaam &&
                   Email == other.Email &&
                   Geboortedatum == other.Geboortedatum;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserName, Voornaam, Achternaam, Email, Geboortedatum);
        }
    }
}

