using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_xemphim.Data;

namespace Web_xemphim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminsAccountsController : Controller
    {
        private readonly MovieContext _context;

        public AdminsAccountsController(MovieContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminsAccounts
        public async Task<IActionResult> Index()
        {
              return _context.AdminsAccounts != null ? 
                          View(await _context.AdminsAccounts.ToListAsync()) :
                          Problem("Entity set 'MovieContext.AdminsAccounts'  is null.");
        }

        // GET: Admin/AdminsAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminsAccounts == null)
            {
                return NotFound();
            }

            var adminsAccount = await _context.AdminsAccounts
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (adminsAccount == null)
            {
                return NotFound();
            }

            return View(adminsAccount);
        }

        // GET: Admin/AdminsAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminsAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,Name,Password,Checked")] AdminsAccount adminsAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminsAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminsAccount);
        }

        // GET: Admin/AdminsAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminsAccounts == null)
            {
                return NotFound();
            }

            var adminsAccount = await _context.AdminsAccounts.FindAsync(id);
            if (adminsAccount == null)
            {
                return NotFound();
            }
            return View(adminsAccount);
        }

        // POST: Admin/AdminsAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminId,Name,Password,Checked")] AdminsAccount adminsAccount)
        {
            if (id != adminsAccount.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminsAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminsAccountExists(adminsAccount.AdminId))
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
            return View(adminsAccount);
        }

        // GET: Admin/AdminsAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminsAccounts == null)
            {
                return NotFound();
            }

            var adminsAccount = await _context.AdminsAccounts
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (adminsAccount == null)
            {
                return NotFound();
            }

            return View(adminsAccount);
        }

        // POST: Admin/AdminsAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminsAccounts == null)
            {
                return Problem("Entity set 'MovieContext.AdminsAccounts'  is null.");
            }
            var adminsAccount = await _context.AdminsAccounts.FindAsync(id);
            if (adminsAccount != null)
            {
                _context.AdminsAccounts.Remove(adminsAccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminsAccountExists(int id)
        {
          return (_context.AdminsAccounts?.Any(e => e.AdminId == id)).GetValueOrDefault();
        }
    }
}
