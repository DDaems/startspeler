using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Areas.Admin.Models.Export
{
    public class ExportModel
    {
        public List<ExportItemModel> ExportItems { get; set; }

        public string Errors { get; set; }
    }
}
