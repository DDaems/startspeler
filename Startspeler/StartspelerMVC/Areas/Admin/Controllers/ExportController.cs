using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StartspelerMVC.Areas.Admin.Models.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ExportController : Controller
    {
        // GET: ExportController
        public ActionResult Index()
        {
            var model = createExportList();

                return View(model);
        }

        public ExportModel createExportList()
        {
            var model = new ExportModel
            {
                ExportItems = new[]
    {
                new ExportItemModel { Naam = "Gebruikers" },
                new ExportItemModel { Naam = "Producten" },
                new ExportItemModel { Naam = "Drankkaarten" },
                new ExportItemModel { Naam = "Inschrijvingen" },
                new ExportItemModel { Naam = "Evenementen" },
                new ExportItemModel { Naam = "Emails" },
                new ExportItemModel { Naam = "Stock" },
                    }.ToList()
            };
            return model;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Download(ExportModel model)
        {
            // nog afhandelen
            model = createExportList();
            model.Errors = "Succes!";
            return View("Index", model);
        }

    }
}
