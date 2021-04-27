using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StartspelerMVC.Data;
using StartspelerMVC.Models;

namespace StartspelerMVC.Controllers
{
    public class DrankkaartsController : Controller
    {
        private readonly StartspelerContext _context;

        public DrankkaartsController(StartspelerContext context)
        {
            _context = context;
        }

        // GET: Drankkaarts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drankkaarten.ToListAsync());
        }

        // GET: Drankkaarts/Details/5
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

        // GET: Drankkaarts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drankkaarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrankkaartID,userID,Aantal_Verbruikt,DrankkaartTypeID")] Drankkaart drankkaart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drankkaart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drankkaart);
        }

        // GET: Drankkaarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankkaart = await _context.Drankkaarten.FindAsync(id);
            if (drankkaart == null)
            {
                return NotFound();
            }
            return View(drankkaart);
        }

        // POST: Drankkaarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrankkaartID,userID,Aantal_Verbruikt,DrankkaartTypeID")] Drankkaart drankkaart)
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
                return RedirectToAction(nameof(Index));
            }
            return View(drankkaart);
        }

        // GET: Drankkaarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Drankkaarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drankkaart = await _context.Drankkaarten.FindAsync(id);
            _context.Drankkaarten.Remove(drankkaart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrankkaartExists(int id)
        {
            return _context.Drankkaarten.Any(e => e.DrankkaartID == id);
        }
    }
}
