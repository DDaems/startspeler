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

namespace StartspelerMVC.Controllers
{
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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producten.ToListAsync());
        }

        public async Task<IActionResult> BevestigBestelling(OverzichtProductViewModel viewmodel)
        {
            int i = 0;
            float prijs = 0;
            foreach (var item in viewmodel.Bestelling.Items)
            {
                viewmodel.Bestelling.Items[i].Prod = _context.Producten.Include(x => x.Categorie).Where(x => x.ProductID == item.ProductId).FirstOrDefault();
                prijs = prijs + item.Aantal * viewmodel.Bestelling.Items[i].Prod.Prijs;

                //   _context.Add(viewmodel.Bestelling.Items[i]);
                //   await _context.SaveChangesAsync();
                i++;
            }
            //var gebruiker =  await _userManager.GetUserAsync(HttpContext.User);
            viewmodel.TotalePrijs = prijs;
            //viewmodel.Bestelling.User.Id = gebruiker.Id;

            //  _context.Add(viewmodel.Bestelling);
            //  await _context.SaveChangesAsync();
            return View(viewmodel);
        }

        public async Task<IActionResult> VerificatieBestelling(OverzichtProductViewModel viewmodel)
        {
            return View();
        }

        public async Task<IActionResult> Drankoverzicht(OverzichtProductViewModel initieelmodel)
        {
            if (initieelmodel.Bestelling == null)
            {
                OverzichtProductViewModel viewmodel = new OverzichtProductViewModel();
                viewmodel.Producten = await _context.Producten.Include(x => x.Categorie).ToListAsync();
                viewmodel.Categories = await _context.Categories.ToListAsync();
                viewmodel.Bestelling = new Bestelling();

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
                return View(initieelmodel);
            }
        }

        // GET: Stockbeheer
        public async Task<IActionResult> Stockbeheer()
        {
            return View(await _context.Producten.ToListAsync());
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
            //viewmodel.NieuwProduct = new Product();
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
                return RedirectToAction(nameof(Index));
            }

            return View(viewmodel);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Naam,Prijs,Ijskast,OverigeStock,CategorieID")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
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