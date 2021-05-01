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
        [Key]
        public int DrankkaartID { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }

        public int Aantal_beschikbaar { get; set; }

        public string Status { get; set; }

        public DateTime Aankoopdatum { get; set; }

        
        public int DrankkaartTypeID { get; set; }
    }
}