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
        }

        [Key]
        public int DrankkaartID { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Display(Name = "Aantal beschikbaar")]
        public int Aantal_beschikbaar { get; set; }

        public string Status { get;  set; }

        public DateTime Aankoopdatum { get; set; }

        [ForeignKey("DrankkaartTypeID")]
        public int? DrankkaartTypeID { get; set; }
       
        public DrankkaartType DrankkaartType { get; set; }

        // public virtual ICollection<DrankkaartType> DrankkaartType { get; set; }


    }
}