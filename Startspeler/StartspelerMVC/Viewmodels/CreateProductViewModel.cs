using Microsoft.AspNetCore.Mvc.Rendering;
using StartspelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Viewmodels
{
    public class CreateProductViewModel
    {
        public Product NieuwProduct { get; set; }

        public SelectList Categories { get; set; }
    }
}