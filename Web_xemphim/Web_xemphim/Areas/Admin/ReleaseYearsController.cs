using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_xemphim.Data;

namespace Web_xemphim.Areas.Admin
{
    [Area("Admin")]
    public class ReleaseYearsController : Controller
    {
        private readonly MovieContext _context;

        public ReleaseYearsController(MovieContext context)
        {
            _context = context;
        }

        // GET: Admin/ReleaseYears
        public async Task<IActionResult> Index()
        {
              return _context.ReleaseYears != null ? 
                          View(await _context.ReleaseYears.ToListAsync()) :
                          Problem("Entity set 'MovieContext.ReleaseYears'  is null.");
        }

        // GET: Admin/ReleaseYears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReleaseYears == null)
            {
                return NotFound();
            }

            var releaseYear = await _context.ReleaseYears
                .FirstOrDefaultAsync(m => m.ReleaseYearId == id);
            if (releaseYear == null)
            {
                return NotFound();
            }

            return View(releaseYear);
        }

        // GET: Admin/ReleaseYears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ReleaseYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReleaseYearId,YearRelease")] ReleaseYear releaseYear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(releaseYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(releaseYear);
        }

        // GET: Admin/ReleaseYears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReleaseYears == null)
            {
                return NotFound();
            }

            var releaseYear = await _context.ReleaseYears.FindAsync(id);
            if (releaseYear == null)
            {
                return NotFound();
            }
            return View(releaseYear);
        }

        // POST: Admin/ReleaseYears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReleaseYearId,YearRelease")] ReleaseYear releaseYear)
        {
            if (id != releaseYear.ReleaseYearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(releaseYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReleaseYearExists(releaseYear.ReleaseYearId))
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
            return View(releaseYear);
        }

        // GET: Admin/ReleaseYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReleaseYears == null)
            {
                return NotFound();
            }

            var releaseYear = await _context.ReleaseYears
                .FirstOrDefaultAsync(m => m.ReleaseYearId == id);
            if (releaseYear == null)
            {
                return NotFound();
            }

            return View(releaseYear);
        }

        // POST: Admin/ReleaseYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReleaseYears == null)
            {
                return Problem("Entity set 'MovieContext.ReleaseYears'  is null.");
            }
            var releaseYear = await _context.ReleaseYears.FindAsync(id);
            if (releaseYear != null)
            {
                _context.ReleaseYears.Remove(releaseYear);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReleaseYearExists(int id)
        {
          return (_context.ReleaseYears?.Any(e => e.ReleaseYearId == id)).GetValueOrDefault();
        }
    }
}
