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

namespace StartspelerMVC.Controllers
{
    public class EvenementController : Controller
    {
        private readonly StartspelerContext _context;

        public EvenementController(StartspelerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Overzicht()
        {
            OverzichtEvenementViewModel viewmodel = new OverzichtEvenementViewModel();
            viewmodel.LiveEvenementen = await _context.Evenementen
                .Where(x => x.Startdatum < DateTime.Now)
                .Where(x => x.Einddatum > DateTime.Now)
                .ToListAsync();

            viewmodel.AankomendeEvenementen = await _context.Evenementen
                .Where(x => x.Startdatum > DateTime.Now)
                .ToListAsync();

            //Afgelopen 6 maanden
            viewmodel.AfgelopenEvenementen = await _context.Evenementen
                .Where(x => x.Einddatum.AddMonths(6) > DateTime.Now)
                .Where(x => x.Einddatum < DateTime.Now)
                .ToListAsync();

            return View(viewmodel);
        }

        // GET: Evenement
        public async Task<IActionResult> Index()
        {
            return View(await _context.Evenementen.ToListAsync());
        }

        // GET: Evenement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenementen
                .FirstOrDefaultAsync(m => m.EvenementID == id);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // GET: Evenement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evenement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvenementID,Titel,Startdatum,Beschrijving,Kostprijs,Max_Deelnemers,Einddatum,EvenementTypeID")] Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evenement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evenement);
        }

        // GET: Evenement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenementen.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }
            return View(evenement);
        }

        // POST: Evenement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvenementID,Titel,Startdatum,Beschrijving,Kostprijs,Max_Deelnemers,Einddatum,EvenementTypeID")] Evenement evenement)
        {
            if (id != evenement.EvenementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evenement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenementExists(evenement.EvenementID))
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
            return View(evenement);
        }

        // GET: Evenement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenementen
                .FirstOrDefaultAsync(m => m.EvenementID == id);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // POST: Evenement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evenement = await _context.Evenementen.FindAsync(id);
            _context.Evenementen.Remove(evenement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvenementExists(int id)
        {
            return _context.Evenementen.Any(e => e.EvenementID == id);
        }
    }
}