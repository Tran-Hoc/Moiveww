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
    public class NationalsController : Controller
    {
        private readonly MovieContext _context;

        public NationalsController(MovieContext context)
        {
            _context = context;
        }

        // GET: Admin/Nationals
        public async Task<IActionResult> Index()
        {
              return _context.Nationals != null ? 
                          View(await _context.Nationals.ToListAsync()) :
                          Problem("Entity set 'MovieContext.Nationals'  is null.");
        }

        // GET: Admin/Nationals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nationals == null)
            {
                return NotFound();
            }

            var national = await _context.Nationals
                .FirstOrDefaultAsync(m => m.NationalsId == id);
            if (national == null)
            {
                return NotFound();
            }

            return View(national);
        }

        // GET: Admin/Nationals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Nationals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NationalsId,NameNational")] National national)
        {
            if (ModelState.IsValid)
            {
                _context.Add(national);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(national);
        }

        // GET: Admin/Nationals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nationals == null)
            {
                return NotFound();
            }

            var national = await _context.Nationals.FindAsync(id);
            if (national == null)
            {
                return NotFound();
            }
            return View(national);
        }

        // POST: Admin/Nationals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NationalsId,NameNational")] National national)
        {
            if (id != national.NationalsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(national);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NationalExists(national.NationalsId))
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
            return View(national);
        }

        // GET: Admin/Nationals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nationals == null)
            {
                return NotFound();
            }

            var national = await _context.Nationals
                .FirstOrDefaultAsync(m => m.NationalsId == id);
            if (national == null)
            {
                return NotFound();
            }

            return View(national);
        }

        // POST: Admin/Nationals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nationals == null)
            {
                return Problem("Entity set 'MovieContext.Nationals'  is null.");
            }
            var national = await _context.Nationals.FindAsync(id);
            if (national != null)
            {
                _context.Nationals.Remove(national);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NationalExists(int id)
        {
          return (_context.Nationals?.Any(e => e.NationalsId == id)).GetValueOrDefault();
        }
    }
}
