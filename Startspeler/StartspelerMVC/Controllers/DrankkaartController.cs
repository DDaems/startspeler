using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StartspelerMVC.Data;
using StartspelerMVC.Models;
using StartspelerMVC.Viewmodels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace StartspelerMVC.Controllers
{
    public class DrankkaartController : Controller
    {
        private readonly StartspelerContext _context;
        private UserManager<User> _userManager;

        public DrankkaartController(StartspelerContext context, UserManager<User> UserManager)
        {
            _context = context;
            _userManager = UserManager;
        }

        [Authorize]
        // GET: Drankkaart
        public async Task<IActionResult> Index()
        {
            var mailadres = await _userManager.GetUserAsync(HttpContext.User);

            var regel = mailadres.Id.ToString();

            List<UserOverzichtViewModel> listVM = new List<UserOverzichtViewModel>();

            var drankkaartenlijst = (from Drnk in _context.Drankkaarten
                                     join Type in _context.DrankkaartTypes on Drnk.DrankkaartTypeID equals Type.DrankkaartTypeID
                                     join Users in _context.Users on Drnk.UserId equals Users.Id
                                     where Users.Id == regel
                                     orderby Drnk.Aankoopdatum descending
                                     select new { Drnk.DrankkaartID, Drnk.Aankoopdatum, Drnk.Aantal_beschikbaar, Drnk.Status, Type.Grootte }).ToList();
            foreach (var item in drankkaartenlijst)
            {
                UserOverzichtViewModel userDrankkaart = new UserOverzichtViewModel();
                userDrankkaart.Aankoopdatum = item.Aankoopdatum;
                userDrankkaart.Aantal_beschikbaar = item.Aantal_beschikbaar;
                userDrankkaart.DrankkaartID = item.DrankkaartID;
                userDrankkaart.Status = item.Status;
                userDrankkaart.Grootte = item.Grootte;
                listVM.Add(userDrankkaart);
            }

            return View(listVM);
            //return View(await _context.Drankkaarten.ToListAsync());
        }

        public async Task<IActionResult> Overzicht()
        {
            List<OverzichtDrankkaartenViewModel> DrankkaartenVMlijst = new List<OverzichtDrankkaartenViewModel>();

            var drankkaartenlijst = (from Drnk in _context.Drankkaarten

                                     join Type in _context.DrankkaartTypes on Drnk.DrankkaartTypeID equals Type.DrankkaartTypeID
                                     join Users in _context.Users on Drnk.UserId equals Users.Id
                                     orderby Drnk.Aankoopdatum
                                     select new { Drnk.DrankkaartID, Drnk.Aankoopdatum, Drnk.Aantal_beschikbaar, Type.Grootte, Users.Voornaam, Users.Achternaam, Drnk.Status }).ToList();

            foreach (var item in drankkaartenlijst)
            {
                OverzichtDrankkaartenViewModel overzichtItem = new OverzichtDrankkaartenViewModel();
                overzichtItem.Aankoopdatum = item.Aankoopdatum;
                overzichtItem.Aantal_beschikbaar = item.Aantal_beschikbaar;
                overzichtItem.Grootte = item.Grootte;
                overzichtItem.Voornaam = item.Voornaam;
                overzichtItem.Achternaam = item.Achternaam;
                overzichtItem.Status = item.Status;
                overzichtItem.DrankkaartID = item.DrankkaartID;
                DrankkaartenVMlijst.Add(overzichtItem);
            }

            return View(DrankkaartenVMlijst);
        }

        //Search
        public async Task<IActionResult> Search(IEnumerable<OverzichtDrankkaartenViewModel> viewModel)
        {
            var iets = viewModel.SingleOrDefault();
            string zoekterm = iets.Zoekterm;

            /*
            SearchDrankkaartenViewModel searchViewModel = new SearchDrankkaartenViewModel();

                                         join Type in _context.DrankkaartTypes on Drnk.DrankkaartTypeID equals Type.DrankkaartTypeID
                                         join Users in _context.Users on Drnk.UserId equals Users.Id
                                         where Users.Voornaam.Contains(viewModel.Zoekterm) || Users.Achternaam.Contains(viewModel.Zoekterm)
                                         orderby Drnk.Aankoopdatum
                                         select new { Drnk.Aankoopdatum, Drnk.Aantal_beschikbaar, Type.Grootte, Users.Voornaam, Users.Achternaam }).ToList();

            if (!string.IsNullOrEmpty(viewModel.Zoekterm))
            {
                var drankkaartenlijst = (from Drnk in _context.Drankkaarten

                                         join Type in _context.DrankkaartTypes on Drnk.DrankkaartTypeID equals Type.DrankkaartTypeID
                                         join Users in _context.Users on Drnk.UserId equals Users.Id
                                         orderby Drnk.Aankoopdatum
                                         select new { Drnk.Aankoopdatum, Drnk.Aantal_beschikbaar, Type.Grootte, Users.Voornaam, Users.Achternaam }).ToList();

                foreach (var item in drankkaartenlijst)
                {
                    OverzichtDrankkaartenViewModel overzichtItem = new OverzichtDrankkaartenViewModel();
                    overzichtItem.Aankoopdatum = item.Aankoopdatum;
                    overzichtItem.Aantal_beschikbaar = item.Aantal_beschikbaar;
                    overzichtItem.Groote = item.Grootte;
                    overzichtItem.Voornaam = item.Voornaam;
                    overzichtItem.Achternaam = item.Achternaam;
                    DrankkaartenVMlijst.Add(overzichtItem);
                }
            }

            */

            return View("Overzicht", viewModel);
        }

        // GET: Drankkaart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankkaart = await _context.Drankkaarten
                .FirstOrDefaultAsync(m => m.DrankkaartID == id);
            if (drankkaart == null)
            {
                return NotFound();
            }

            return View(drankkaart);
        }

        // GET: Drankkaart/Create
        public IActionResult Create()
        {
            CreateDrankkaartViewModel drankkaartViewModel = new CreateDrankkaartViewModel();
            drankkaartViewModel.Drankkaart = new Drankkaart();
            drankkaartViewModel.DrankkaartType = new SelectList(_context.DrankkaartTypes.OrderBy(x => x.Grootte), "DrankkaartTypeID", "Selectnaam");
            return View(drankkaartViewModel);
        }

        // POST: Drankkaart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDrankkaartViewModel drankkaartVM)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            drankkaartVM.Drankkaart.UserId = user.Id;
            var drankkaarttype = _context.DrankkaartTypes
                .Where(x => x.DrankkaartTypeID == drankkaartVM.Drankkaart.DrankkaartTypeID)
                 .SingleOrDefault();

            drankkaartVM.Drankkaart.Aantal_beschikbaar = drankkaarttype.Grootte;
            drankkaartVM.Drankkaart.Aankoopdatum = DateTime.Now;
            drankkaartVM.Drankkaart.Status = "Openstaand";

            if (ModelState.IsValid)
            {
                _context.Add(drankkaartVM.Drankkaart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(drankkaartVM);
        }

        // [Authorize(Roles = "Admin")]
        // GET: Drankkaart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            CreateDrankkaartViewModel drankkaartViewModel = new CreateDrankkaartViewModel();
            drankkaartViewModel.Drankkaart = new Drankkaart();
            drankkaartViewModel.DrankkaartType = new SelectList(_context.DrankkaartTypes, "DrankkaartTypeID", "Selectnaam");

            List<string> lijstStatussen = new List<string>();
            lijstStatussen.Add("Betaald");
            lijstStatussen.Add("Openstaand");

            drankkaartViewModel.Statussen = new SelectList(lijstStatussen);

            if (id == null)
            {
                return NotFound();
            }

            drankkaartViewModel.Drankkaart = await _context.Drankkaarten.FindAsync(id);
            drankkaartViewModel.Drankkaart.UserId = drankkaartViewModel.Drankkaart.UserId;
            if (drankkaartViewModel.Drankkaart == null)
            {
                return NotFound();
            }
            return View(drankkaartViewModel);
        }

        // POST: Drankkaart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Aankoopdatum, DrankkaartID,UserId, Aantal_beschikbaar,Status,DrankkaartTypeID")] Drankkaart drankkaart)
        {
            if (id != drankkaart.DrankkaartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drankkaart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrankkaartExists(drankkaart.DrankkaartID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Overzicht));
            }
            return View(drankkaart);
        }

        // GET: Drankkaart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankkaart = await _context.Drankkaarten.Include(x => x.User).Include(x => x.DrankkaartType)
                .Where(x => x.DrankkaartID == id).FirstOrDefaultAsync();
            if (drankkaart == null)
            {
                return NotFound();
            }

            return View(drankkaart);
        }

        // POST: Drankkaart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drankkaart = await _context.Drankkaarten.FindAsync(id);
            _context.Drankkaarten.Remove(drankkaart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Overzicht));
        }

        private bool DrankkaartExists(int id)
        {
            return _context.Drankkaarten.Any(e => e.DrankkaartID == id);
        }
    }
}