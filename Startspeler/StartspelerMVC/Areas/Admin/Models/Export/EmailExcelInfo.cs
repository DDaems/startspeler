using System.Collections.Generic;

namespace StartspelerMVC.Areas.Admin.Models.Export
{
    public class EmailExcelInfo : List<dynamic>
    {
        public string Email { get; set; }
    }
}