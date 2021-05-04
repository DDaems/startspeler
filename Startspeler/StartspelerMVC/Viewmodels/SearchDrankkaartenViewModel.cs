using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Viewmodels
{
    public class SearchDrankkaartenViewModel
    {
        public string Zoekterm { get; set; }
        public IEnumerable<OverzichtDrankkaartenViewModel> overzichtdrankkaarten { get; set; }
    }
}
