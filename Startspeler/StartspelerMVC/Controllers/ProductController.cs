using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StartspelerMVC.Data;
using StartspelerMVC.Models;
using StartspelerMVC.Viewmodels;
using System.Web;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using StartspelerMVC.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace StartspelerMVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly StartspelerContext _context;

        private UserManager<User> _userManager;

        public ProductController(StartspelerContext context, UserManager<User> UserManager)
        {
            _context = context;
            _userManager = UserManager;
        }

        // GET: Product
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(await _context.Producten.ToListAsync());
        }

        public async Task<IActionResult> BevestigBestelling(OverzichtProductViewModel viewmodel)
        {
            var Lijstlijnen = new List<Bestellijn>();
            int i = 0;
            float prijs = 0;
            foreach (var item in viewmodel.Bestelling.Items)
            {
                viewmodel.Bestelling.Items[i].Prod = _context.Producten.Include(x => x.Categorie).Where(x => x.ProductID == item.ProductId).FirstOrDefault();
                prijs = prijs + item.Aantal * viewmodel.Bestelling.Items[i].Prod.Prijs;

                Bestellijn lijn = new Bestellijn()
                {
                    ProductId = item.ProductId,
                    Aantal = item.Aantal,
                };

                //We voegen hier alle bestellijnen toe aan de database. Achteraf moeten we ervoor zorgen dat alle lijnen gewist worden.
                //Hierdoor bewaren we op termijn niet alle individuele lijnen.
                _context.Add(lijn);
                await _context.SaveChangesAsync();

                Lijstlijnen.Add(lijn);

                //   _context.Add(viewmodel.Bestelling.Items[i]);
                //   await _context.SaveChangesAsync();
                i++;
            }
            //var gebruiker =  await _userManager.GetUserAsync(HttpContext.User);
            viewmodel.userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            viewmodel.TotalePrijs = prijs;
            //viewmodel.Bestelling.User.Id = gebruiker.Id;

            Bestelling saveRecord = new Bestelling()
            {
                UserId = viewmodel.userId,
                User = _context.Users.Where(x => x.Id == viewmodel.userId).FirstOrDefault(),
                Items = Lijstlijnen
            };

            _context.Add(saveRecord);
            await _context.SaveChangesAsync();

            return View(viewmodel);
        }

        public async Task<IActionResult> VerificatieBestelling(VerificatieBestellingViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                string userId = viewmodel.userId;
                string pincode = viewmodel.Pincode;
                viewmodel.Errors = "";

                User u = await _userManager.FindByIdAsync(userId);

                if (u != null)
                {
                    var succes = await verficiatiePincode.verify(u, _userManager, pincode);

                    if (succes > 0)
                    {
                        //viewmodel.Errors += "Pincode juist";

                        //Controle ofdat de user voldoende beschikbare drankbonnen heeft

                        #region controle ofdat er genoeg stock is, en ofdat user voldoende consumpties heeft.

                        var drankkaartenlijst = await _context.Drankkaarten.Where(x => x.UserId == userId).ToListAsync();

                        int TotaalAantalBeschikbaar = 0;
                        foreach (var item in drankkaartenlijst)
                        {
                            TotaalAantalBeschikbaar += item.Aantal_beschikbaar;
                        }
                        string Errors = "";
                        var bestellijnlijst = await _context.Bestellijnen.ToListAsync();
                        int TotalePrijs = 0;
                        foreach (var item in bestellijnlijst)
                        {
                            var product = await _context.Producten.Where(x => x.ProductID == item.ProductId).FirstOrDefaultAsync();
                            TotalePrijs = TotalePrijs + item.Aantal * (int)product.Prijs;
                            if (product.Ijskast < item.Aantal)
                            {
                                Errors += "Er is een onvoldoende voorraad van " + item.Prod.Naam + " beschikbaar" + Environment.NewLine;
                            }
                        }

                        if (TotaalAantalBeschikbaar < TotalePrijs)   //Niet voldoende beschikbaar
                        {
                            Errors += "Je hebt niet genoeg drankconsumpties beschikbaar" + Environment.NewLine;
                        }

                        if (!string.IsNullOrEmpty(Errors)) // Als er een Error is, Genereer dan het een vorige view model met de bestelling uit de db.
                                                           //Omdat de db telkens wordt leeggemaakt bij het opstarten van Drankoverzicht, is alles wat er in zit van de gebruiker!
                        {
                            OverzichtProductViewModel VorigeViewmodel = new OverzichtProductViewModel();
                            VorigeViewmodel.Errors += Errors;
                            VorigeViewmodel.Categories = await _context.Categories.ToListAsync();
                            VorigeViewmodel.Bestelling = new Bestelling();
                            VorigeViewmodel.userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                            VorigeViewmodel.Producten = await _context.Producten.Include(x => x.Categorie).ToListAsync();

                            List<Bestellijn> nieuwelijst = new List<Bestellijn>();
                            int i = 0;
                            //Logica om een lege shopping cart aan te maken.

                            var origineleBestellijnen = await _context.Bestellijnen.ToListAsync();

                            foreach (var product in VorigeViewmodel.Producten)
                            {
                                Bestellijn bestellijn = new Bestellijn(product.ProductID)
                                {
                                    BestellijnID = origineleBestellijnen[i].BestellijnID,
                                    Aantal = origineleBestellijnen[i].Aantal,
                                    Prod = product
                                };
                                i++;
                                VorigeViewmodel.TotalePrijs = VorigeViewmodel.TotalePrijs + bestellijn.Aantal * bestellijn.Prod.Prijs;
                                nieuwelijst.Add(bestellijn);
                            }
                            VorigeViewmodel.Bestelling.BestellingID = 1;
                            VorigeViewmodel.Bestelling.Items = nieuwelijst;

                            return View("BevestigBestelling", VorigeViewmodel);
                        }

                        #endregion controle ofdat er genoeg stock is, en ofdat user voldoende consumpties heeft.

                        //Hier is alle validatie uitgevoerd. Nu weet je dat je kan verrekenen.

                        #region afhandelen van de gevalideerde bestelling.

                        int Restprijs = TotalePrijs;

                        for (int j = 0; j < drankkaartenlijst.Count; j++)
                        {
                            if (Restprijs - drankkaartenlijst[j].Aantal_beschikbaar >= 0)
                            {
                                Restprijs = Restprijs - drankkaartenlijst[j].Aantal_beschikbaar;
                                drankkaartenlijst[j].Aantal_beschikbaar = 0;
                            }
                            else
                            {
                                drankkaartenlijst[j].Aantal_beschikbaar = drankkaartenlijst[j].Aantal_beschikbaar - Restprijs;
                                Restprijs = 0;
                            }

                            _context.Update(drankkaartenlijst[j]);
                            await _context.SaveChangesAsync();
                        }

                        foreach (var item in bestellijnlijst)
                        {
                            var product = await _context.Producten.Where(x => x.ProductID == item.ProductId).FirstOrDefaultAsync();
                            product.Ijskast = product.Ijskast - item.Aantal;

                            _context.Update(item);
                            await _context.SaveChangesAsync();
                        }

                        #endregion afhandelen van de gevalideerde bestelling.

                        VerificatieBestellingViewModel nieuwViewmodel = new VerificatieBestellingViewModel();

                        //Verdere validatie van stock en drankbonnencorrectie van de user.

                        return View("VerificatieBestelling", nieuwViewmodel);
                    }
                    else
                    {
                        //Terug naar BevestigBestelling, met de opgeslagen viewmodel.
                        //Errors string ergens tonen bij de keypad.

                        OverzichtProductViewModel VorigeViewmodel = new OverzichtProductViewModel();

                        VorigeViewmodel.Errors += "Pincode verificatie is gefaald. probeer opnieuw";
                        VorigeViewmodel.Categories = await _context.Categories.ToListAsync();
                        VorigeViewmodel.Bestelling = new Bestelling();
                        VorigeViewmodel.userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                        VorigeViewmodel.Producten = await _context.Producten.Include(x => x.Categorie).ToListAsync();

                        List<Bestellijn> nieuwelijst = new List<Bestellijn>();
                        int i = 0;
                        //Logica om een lege shopping cart aan te maken.

                        var origineleBestellijnen = await _context.Bestellijnen.ToListAsync();

                        foreach (var product in VorigeViewmodel.Producten)
                        {
                            Bestellijn bestellijn = new Bestellijn(product.ProductID)
                            {
                                BestellijnID = origineleBestellijnen[i].BestellijnID,
                                Aantal = origineleBestellijnen[i].Aantal,
                                Prod = product
                            };
                            i++;
                            VorigeViewmodel.TotalePrijs = VorigeViewmodel.TotalePrijs + bestellijn.Aantal * bestellijn.Prod.Prijs;

                            nieuwelijst.Add(bestellijn);
                        }
                        VorigeViewmodel.Bestelling.BestellingID = 1;
                        VorigeViewmodel.Bestelling.Items = nieuwelijst;

                        return View("BevestigBestelling", VorigeViewmodel);
                    }
                }
                else
                {
                    // Aanmeldingsfout. Deze situatie komt nooit voor. Numpad wordt niet eens getoond aan een niet-ingelogde gebruiker.

                    // viewmodel.Errors += "U moet eerst aanmelden alvorens een bestelling te plaatsen.";
                    return View("Drankoverzicht", viewmodel);
                }
            }

            //Terug naar landingspagina. Er ging iets mis.

            return View("Drankoverzicht", viewmodel);
        }

        public async Task<IActionResult> Drankoverzicht(OverzichtProductViewModel initieelmodel)
        {
            //Wissen van de bestelling in het geval er nog lijnen zouden instaan.
            ResetBestelling();

            if (initieelmodel.Bestelling == null)
            {
                OverzichtProductViewModel viewmodel = new OverzichtProductViewModel();
                viewmodel.Producten = await _context.Producten.Include(x => x.Categorie).OrderBy(x => x.CategorieID).ToListAsync();
                viewmodel.Categories = await _context.Categories.ToListAsync();
                viewmodel.Bestelling = new Bestelling();
                viewmodel.userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                List<Bestellijn> nieuwelijst = new List<Bestellijn>();
                int i = 0;
                //Logica om een lege shopping cart aan te maken.
                foreach (var product in viewmodel.Producten)
                {
                    i++;

                    Bestellijn bestellijn = new Bestellijn(product.ProductID)
                    {
                        BestellijnID = i,
                        Aantal = 0,
                        Prod = product
                    };
                    nieuwelijst.Add(bestellijn);
                }
                viewmodel.Bestelling.BestellingID = 1;
                viewmodel.Bestelling.Items = nieuwelijst;
                return View(viewmodel);

                //Naar de view wordt een lege Bestelling gestuurd.
            }
            else
            {
                //Anders stuur je de vorige view terug. (Bijvoorbeeld wanneer je toch iets wil aanpassen aan je shoppingcart)
                initieelmodel.userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                return View(initieelmodel);
            }
        }

        private void ResetBestelling()
        {
            _context.Bestellingen.RemoveRange(_context.Bestellingen.ToList());
            _context.SaveChanges();

            _context.Bestellijnen.RemoveRange(_context.Bestellijnen.ToList());
            _context.SaveChanges();
        }

        // GET: Stockbeheer
        public async Task<IActionResult> Stockbeheer()
        {
            return View(await _context.Producten
                .OrderBy(x => x.CategorieID)
                .ToListAsync());
        }

        // GET: product gefilterd op categorie

        public async Task<IActionResult> Search(OverzichtProductViewModel viewmodel)
        {
            viewmodel.Categories = await _context.Categories.ToListAsync();
            viewmodel.Bestelling = new Bestelling();

            if (!string.IsNullOrEmpty(viewmodel.CategorieSearch))
            {
                if (viewmodel.CategorieSearch == "Alles")
                {
                    var alleproducten = await _context.Producten.Include(b => b.Categorie).ToListAsync();

                    viewmodel.Bestelling.Items = new List<Bestellijn>();
                    foreach (var product in alleproducten)
                    {
                        Bestellijn nieuwelijn = new Bestellijn()
                        {
                            Prod = product,
                            Aantal = 0
                        };
                        viewmodel.Bestelling.Items.Add(nieuwelijn);
                    }
                }
                else
                {
                    var filterproducten = await _context.Producten.Include(x => x.Categorie).Where(x => x.Categorie.Naam.Contains(viewmodel.CategorieSearch)).ToListAsync();

                    viewmodel.Bestelling.Items = new List<Bestellijn>();
                    foreach (var product in filterproducten)
                    {
                        Bestellijn nieuwelijn = new Bestellijn()
                        {
                            Prod = product,
                            Aantal = 0
                        };
                        viewmodel.Bestelling.Items.Add(nieuwelijn);
                    }
                }

                return View("DrankOverzicht", viewmodel);
            }

            return View("DrankOverzicht", viewmodel);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            CreateProductViewModel viewmodel = new CreateProductViewModel();
            viewmodel.NieuwProduct = new Product();
            viewmodel.Categories = new SelectList(_context.Categories, "CategorieID", "Naam");
            return View(viewmodel);
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewmodel.NieuwProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Stockbeheer));
            }

            return View(viewmodel);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            CreateProductViewModel viewmodel = new CreateProductViewModel();
            if (id == null)
            {
                return NotFound();
            }

            viewmodel.NieuwProduct = await _context.Producten.FindAsync(id);
            viewmodel.Categories = new SelectList(_context.Categories, "CategorieID", "Naam");
            if (viewmodel.NieuwProduct == null)
            {
                return NotFound();
            }
            return View(viewmodel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateProductViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewmodel.NieuwProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(viewmodel.NieuwProduct.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Stockbeheer));
            }
            return View(viewmodel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Producten.FindAsync(id);
            _context.Producten.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Producten.Any(e => e.ProductID == id);
        }
    }
}