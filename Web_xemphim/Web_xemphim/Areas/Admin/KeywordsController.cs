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
    public class KeywordsController : Controller
    {
        private readonly MovieContext _context;

        public KeywordsController(MovieContext context)
        {
            _context = context;
        }

        // GET: Admin/Keywords
        public async Task<IActionResult> Index()
        {
              return _context.Keywords != null ? 
                          View(await _context.Keywords.ToListAsync()) :
                          Problem("Entity set 'MovieContext.Keywords'  is null.");
        }

        // GET: Admin/Keywords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Keywords == null)
            {
                return NotFound();
            }

            var keyword = await _context.Keywords
                .FirstOrDefaultAsync(m => m.KeywordId == id);
            if (keyword == null)
            {
                return NotFound();
            }

            return View(keyword);
        }

        // GET: Admin/Keywords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Keywords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KeywordId,Word")] Keyword keyword)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keyword);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keyword);
        }

        // GET: Admin/Keywords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Keywords == null)
            {
                return NotFound();
            }

            var keyword = await _context.Keywords.FindAsync(id);
            if (keyword == null)
            {
                return NotFound();
            }
            return View(keyword);
        }

        // POST: Admin/Keywords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KeywordId,Word")] Keyword keyword)
        {
            if (id != keyword.KeywordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keyword);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeywordExists(keyword.KeywordId))
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
            return View(keyword);
        }

        // GET: Admin/Keywords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Keywords == null)
            {
                return NotFound();
            }

            var keyword = await _context.Keywords
                .FirstOrDefaultAsync(m => m.KeywordId == id);
            if (keyword == null)
            {
                return NotFound();
            }

            return View(keyword);
        }

        // POST: Admin/Keywords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Keywords == null)
            {
                return Problem("Entity set 'MovieContext.Keywords'  is null.");
            }
            var keyword = await _context.Keywords.FindAsync(id);
            if (keyword != null)
            {
                _context.Keywords.Remove(keyword);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeywordExists(int id)
        {
          return (_context.Keywords?.Any(e => e.KeywordId == id)).GetValueOrDefault();
        }
    }
}
