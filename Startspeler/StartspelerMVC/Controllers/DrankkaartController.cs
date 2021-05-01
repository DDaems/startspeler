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
    public class DrankkaartController : Controller
    {
        private readonly StartspelerContext _context;

        public DrankkaartController(StartspelerContext context)
        {
            _context = context;
        }

        // GET: Drankkaart
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drankkaarten.ToListAsync());
            
        }

        public async Task<IActionResult> Overzicht()
        {

            StartspelerContext dbContext = _context;

            List<OverzichtDrankkaartenViewModel> DrankkaartenVMlijst = new List<OverzichtDrankkaartenViewModel>();

            var drankkaartenlijst = (from Drnk in dbContext.Drankkaarten

                                     join Type in dbContext.DrankkaartTypes on Drnk.DrankkaartTypeID equals Type.DrankkaartTypeID
                                     //join Userss in dbContext.Users on Drnk.UserID equals Userss.Id
                                     orderby Drnk.Aankoopdatum
                                     select new { Drnk.Aankoopdatum, Drnk.Aantal_beschikbaar, Type.Grootte, Userss.Id }).ToList();

            foreach (var item in drankkaartenlijst)
            {
                OverzichtDrankkaartenViewModel overzichtItem = new OverzichtDrankkaartenViewModel();
                overzichtItem.Aankoopdatum = item.Aankoopdatum;
                overzichtItem.Aantal_beschikbaar = item.Aantal_beschikbaar;
                overzichtItem.Groote = item.Grootte;
                DrankkaartenVMlijst.Add(overzichtItem);


            }
            
            /*

            var drankkaartenlijst = await _context.DrankkaartTypes
                 .Include(x => x.Drankkaarten)
                 .ToListAsync();
            */

            return View(DrankkaartenVMlijst);
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
            return View();
        }

        // POST: Drankkaart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrankkaartID,Aantal_beschikbaar,Status,Aankoopdatum,DrankkaartTypeID")] Drankkaart drankkaart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drankkaart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drankkaart);
        }

        // GET: Drankkaart/Edit/5
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

        // POST: Drankkaart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrankkaartID,Aantal_beschikbaar,Status,Aankoopdatum,DrankkaartTypeID")] Drankkaart drankkaart)
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

        // GET: Drankkaart/Delete/5
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

        // POST: Drankkaart/Delete/5
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
