using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartspelerMVC.Areas.Admin.Models.Export;
using StartspelerMVC.Data;
using StartspelerMVC.Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StartspelerMVC.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ExportController : Controller
    {
        private readonly StartspelerContext ctx;

        public ExportController(StartspelerContext ctx)
        {
            this.ctx = ctx;
        }

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
                ExportItems = new[]{
                new ExportItemModel { Naam = "Gebruikers" },
                new ExportItemModel { Naam = "Drankkaarten" },
                new ExportItemModel { Naam = "Stock" },
                new ExportItemModel { Naam = "Emails" },
                }.ToList()
            };
            return model;
        }

        public ActionResult Download(ExportModel model)
        {

            if (ModelState.IsValid)
            {
                using (var workbook = new XLWorkbook())
                {
                    var incoming = model;
                    if (incoming != null)
                    {
                        foreach (var item in incoming.ExportItems)
                        {

                            if (item.isSelected)
                            {
                                IList data = ophalenData(item.Naam);

                                if (data != null)
                                {
                                    var worksheet = workbook.Worksheets.Add(item.Naam);
                                    var currentRow = 1;
                                    var currentCol = 1;
                                    var initHeader = true;

                                    #region Styling
                                    var headerStyle = XLWorkbook.DefaultStyle;
                                    //headerStyle.Fill.SetBackgroundColor(XLColor.Red);
                                    headerStyle.Font.SetBold(true);
                                    headerStyle.Font.SetFontSize(15);
                                    #endregion

                                    foreach (dynamic row in data)
                                    {
                                        if (initHeader)
                                        {
                                            foreach (var prop in row.GetType().GetProperties())
                                            {
                                                if (prop.Name == "Capacity" || prop.Name == "Count" || prop.Name == "Item") continue;
                                                worksheet.Cell(currentRow, currentCol).Value = prop.Name;
                                                worksheet.Cell(currentRow, currentCol).Style = headerStyle;
                                                currentCol++;
                                            }
                                            currentRow++;
                                            currentCol = 1;
                                            initHeader = false;
                                        }

                                        foreach (var col in row)
                                        {
                                            worksheet.Cell(currentRow, currentCol).Value = col;
                                            currentCol++;
                                        }
                                        currentCol = 1;
                                        currentRow++;
                                    }
                                    
                                }
                                data = null;
                                foreach (var worksheet in workbook.Worksheets)
                                {
                                    worksheet.Columns().AdjustToContents();
                                }
                            }
                        }
                        

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();

                            return File(
                                content,
                                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                                "startspelers.xlsx");
                        }
                        
                    }
                }
                // TODO: log: exportmodel niet geldig
            }

                model = createExportList();
                model.Errors = "Export mislukt!";
                return View("Index", model);
            

        }

        public IList ophalenData(string naam)
        {
            switch (naam)
            {
                case "Gebruikers":
                    List<GebruikersExcelInfo> gebruikerslijst = ctx.Users.AsNoTracking().Select<User, GebruikersExcelInfo>(i => new GebruikersExcelInfo
                    {
                        i.UserName,
                        i.Voornaam,
                        i.Achternaam,
                        i.Email,
                        i.Geboortedatum
                    }
                    ).ToList();
                    return gebruikerslijst;

                case "Drankkaarten":
                    // Orginele Q van Jan
                    var drankkaartenlijst = (from Drnk in ctx.Drankkaarten
                                             join Type in ctx.DrankkaartTypes on Drnk.DrankkaartTypeID equals Type.DrankkaartTypeID
                                             join Users in ctx.Users on Drnk.UserID equals Users.Id
                                             orderby Drnk.Aankoopdatum
                                             select new DrankkaartExcelInfo { Users.UserName, Users.Voornaam, Users.Achternaam, Drnk.Aankoopdatum, Drnk.Aantal_beschikbaar, Type.Grootte, Drnk.Status }).ToList();

                    return drankkaartenlijst;

                case "Emails":
                    List<EmailExcelInfo> emaillijst = ctx.Users.AsNoTracking().Select<User, EmailExcelInfo>(i => new EmailExcelInfo
                    {
                        i.Email,
                    }).ToList();
                    return emaillijst;

                case "Stock":
                    List<ProductExcelInfo> productenlijst = ctx.Producten.AsNoTracking().Select<Product, ProductExcelInfo>(i => new ProductExcelInfo{
                        i.Categorie.Naam, i.Naam, i.Prijs, i.Ijskast, i.OverigeStock, i.Ijskast+i.OverigeStock
                    }).ToList();
                    return productenlijst;

                default:
                    return null;
            }
        }
    }
}

