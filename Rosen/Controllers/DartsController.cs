using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rosen.Data;
using Rosen.Models;

namespace Rosen.Controllers
{
    public class DartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Darts
        public async Task<IActionResult> Index()
        {
              return _context.Darts != null ? 
                          View(await _context.Darts.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Darts'  is null.");
        }

        // GET: Darts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Darts == null)
            {
                return NotFound();
            }

            var darts = await _context.Darts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (darts == null)
            {
                return NotFound();
            }

            return View(darts);
        }

        // GET: Darts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Darts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Player1,Player1Points,Player2,Player2Points,Player3,Player3Points,Player4,Player4Points,Player5,Player5Points,Player6,Player6Points,Player7,Player7Points,Player8,Player8Points,TopPoints,CreatedDate")] Darts darts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(darts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(darts);
        }

        // GET: Darts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Darts == null)
            {
                return NotFound();
            }

            var darts = await _context.Darts.FindAsync(id);
            if (darts == null)
            {
                return NotFound();
            }
            return View(darts);
        }

        // POST: Darts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Player1,Player1Points,Player2,Player2Points,Player3,Player3Points,Player4,Player4Points,Player5,Player5Points,Player6,Player6Points,Player7,Player7Points,Player8,Player8Points,TopPoints,CreatedDate")] Darts darts)
        {
            if (id != darts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(darts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DartsExists(darts.Id))
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
            return View(darts);
        }

        // GET: Darts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Darts == null)
            {
                return NotFound();
            }

            var darts = await _context.Darts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (darts == null)
            {
                return NotFound();
            }

            return View(darts);
        }

        // POST: Darts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Darts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Darts'  is null.");
            }
            var darts = await _context.Darts.FindAsync(id);
            if (darts != null)
            {
                _context.Darts.Remove(darts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DartsExists(int id)
        {
          return (_context.Darts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
