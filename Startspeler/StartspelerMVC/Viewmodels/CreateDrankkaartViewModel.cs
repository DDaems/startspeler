using Microsoft.AspNetCore.Mvc.Rendering;
using StartspelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Viewmodels
{
    public class CreateDrankkaartViewModel
    {
        public Drankkaart Drankkaart { get; set; }
        public SelectList DrankkaartType { get; set; }
        public SelectList Statussen { get; set; }
    }
}
