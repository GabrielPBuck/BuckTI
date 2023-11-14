using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuckTI.Data;
using BuckTI.Models;

namespace BuckTI.Controllers
{
    public class CadSoftwaresController : Controller
    {
        private readonly dbContext _context;

        public CadSoftwaresController(dbContext context)
        {
            _context = context;
        }

        // GET: CadSoftwares
        public async Task<IActionResult> Index()
        {
              return _context.CadSoftwares != null ? 
                          View(await _context.CadSoftwares.ToListAsync()) :
                          Problem("Entity set 'dbContext.CadSoftwares'  is null.");
        }

        // GET: CadSoftwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadSoftwares == null)
            {
                return NotFound();
            }

            var cadSoftwares = await _context.CadSoftwares
                .FirstOrDefaultAsync(m => m.IdSoftware == id);
            if (cadSoftwares == null)
            {
                return NotFound();
            }

            return View(cadSoftwares);
        }

        // GET: CadSoftwares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadSoftwares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSoftware,NomeSoftware,VersaoSoftware,ValidadeSoftware")] CadSoftwares cadSoftwares)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadSoftwares);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadSoftwares);
        }

        // GET: CadSoftwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadSoftwares == null)
            {
                return NotFound();
            }

            var cadSoftwares = await _context.CadSoftwares.FindAsync(id);
            if (cadSoftwares == null)
            {
                return NotFound();
            }
            return View(cadSoftwares);
        }

        // POST: CadSoftwares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSoftware,NomeSoftware,VersaoSoftware,ValidadeSoftware")] CadSoftwares cadSoftwares)
        {
            if (id != cadSoftwares.IdSoftware)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadSoftwares);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadSoftwaresExists(cadSoftwares.IdSoftware))
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
            return View(cadSoftwares);
        }

        // GET: CadSoftwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadSoftwares == null)
            {
                return NotFound();
            }

            var cadSoftwares = await _context.CadSoftwares
                .FirstOrDefaultAsync(m => m.IdSoftware == id);
            if (cadSoftwares == null)
            {
                return NotFound();
            }

            return View(cadSoftwares);
        }

        // POST: CadSoftwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadSoftwares == null)
            {
                return Problem("Entity set 'dbContext.CadSoftwares'  is null.");
            }
            var cadSoftwares = await _context.CadSoftwares.FindAsync(id);
            if (cadSoftwares != null)
            {
                _context.CadSoftwares.Remove(cadSoftwares);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadSoftwaresExists(int id)
        {
          return (_context.CadSoftwares?.Any(e => e.IdSoftware == id)).GetValueOrDefault();
        }
    }
}
