using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    
    public class Drankkaart
    {
        public Drankkaart()
        {
            Aankoopdatum = DateTime.Now;
            Status = "VOL";
            //UserID = "2d05100f - 5382 - 4439 - 857d - 67d80b574d6d";
            //DrankkaartTypeID = 1;
        }
        [Key]
        public int DrankkaartID { get; set; }

        // [ForeignKey("UserID")]
        public string UserID { get; set; }

        public int Aantal_beschikbaar { get; set; }

        public string Status { get; set; }

        public DateTime Aankoopdatum { get; set; }

        
        public int DrankkaartTypeID { get; set; }
    }
}