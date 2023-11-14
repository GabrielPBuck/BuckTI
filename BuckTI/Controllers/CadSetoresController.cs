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
    public class CadSetoresController : Controller
    {
        private readonly dbContext _context;

        public CadSetoresController(dbContext context)
        {
            _context = context;
        }

        // GET: CadSetores
        public async Task<IActionResult> Index()
        {
              return _context.CadSetores != null ? 
                          View(await _context.CadSetores.ToListAsync()) :
                          Problem("Entity set 'dbContext.CadSetores'  is null.");
        }

        // GET: CadSetores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadSetores == null)
            {
                return NotFound();
            }

            var cadSetores = await _context.CadSetores
                .FirstOrDefaultAsync(m => m.IdSetor == id);
            if (cadSetores == null)
            {
                return NotFound();
            }

            return View(cadSetores);
        }

        // GET: CadSetores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadSetores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSetor,NomeSetor,ResponsavelSetor")] CadSetores cadSetores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadSetores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadSetores);
        }

        // GET: CadSetores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadSetores == null)
            {
                return NotFound();
            }

            var cadSetores = await _context.CadSetores.FindAsync(id);
            if (cadSetores == null)
            {
                return NotFound();
            }
            return View(cadSetores);
        }

        // POST: CadSetores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSetor,NomeSetor,ResponsavelSetor")] CadSetores cadSetores)
        {
            if (id != cadSetores.IdSetor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadSetores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadSetoresExists(cadSetores.IdSetor))
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
            return View(cadSetores);
        }

        // GET: CadSetores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadSetores == null)
            {
                return NotFound();
            }

            var cadSetores = await _context.CadSetores
                .FirstOrDefaultAsync(m => m.IdSetor == id);
            if (cadSetores == null)
            {
                return NotFound();
            }

            return View(cadSetores);
        }

        // POST: CadSetores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadSetores == null)
            {
                return Problem("Entity set 'dbContext.CadSetores'  is null.");
            }
            var cadSetores = await _context.CadSetores.FindAsync(id);
            if (cadSetores != null)
            {
                _context.CadSetores.Remove(cadSetores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadSetoresExists(int id)
        {
          return (_context.CadSetores?.Any(e => e.IdSetor == id)).GetValueOrDefault();
        }
    }
}
