using System.Collections.Generic;

namespace StartspelerMVC.Areas.Admin.Models.Export
{
    public class ExportModel
    {
        public List<ExportItemModel> ExportItems { get; set; }

        public string Errors { get; set; }


    }
}
