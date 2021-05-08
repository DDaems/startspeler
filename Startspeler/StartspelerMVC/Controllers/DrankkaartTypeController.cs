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
    public class DrankkaartTypeController : Controller
    {
        private readonly StartspelerContext _context;

        public DrankkaartTypeController(StartspelerContext context)
        {
            _context = context;
        }

        // GET: DrankkaartType
        public async Task<IActionResult> Index()
        {
            return View(await _context.DrankkaartTypes.ToListAsync());
        }

        // GET: DrankkaartType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankkaartType = await _context.DrankkaartTypes
                .FirstOrDefaultAsync(m => m.DrankkaartTypeID == id);
            if (drankkaartType == null)
            {
                return NotFound();
            }

            return View(drankkaartType);
        }

        // GET: DrankkaartType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DrankkaartType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrankkaartTypeID,Grootte")] DrankkaartType drankkaartType)
        {
            if (drankkaartType.Grootte <= 0)
            {
                return View(drankkaartType);
            }

            var drankkaartControle = _context.DrankkaartTypes
                .Where( x => x.Grootte == drankkaartType.Grootte)
                .SingleOrDefault();
            if (drankkaartControle == null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(drankkaartType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(drankkaartType);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DrankkaartType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankkaartType = await _context.DrankkaartTypes.FindAsync(id);
            if (drankkaartType == null)
            {
                return NotFound();
            }
            return View(drankkaartType);
        }

        // POST: DrankkaartType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrankkaartTypeID,Grootte")] DrankkaartType drankkaartType)
        {
            if (id != drankkaartType.DrankkaartTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drankkaartType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrankkaartTypeExists(drankkaartType.DrankkaartTypeID))
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
            return View(drankkaartType);
        }

        // GET: DrankkaartType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankkaartType = await _context.DrankkaartTypes
                .FirstOrDefaultAsync(m => m.DrankkaartTypeID == id);
            if (drankkaartType == null)
            {
                return NotFound();
            }

            return View(drankkaartType);
        }

        // POST: DrankkaartType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drankkaartType = await _context.DrankkaartTypes.FindAsync(id);
            _context.DrankkaartTypes.Remove(drankkaartType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrankkaartTypeExists(int id)
        {
            return _context.DrankkaartTypes.Any(e => e.DrankkaartTypeID == id);
        }
    }
}
