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
    public class UsersMoviesController : Controller
    {
        private readonly MovieContext _context;

        public UsersMoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: Admin/UsersMovies
        public async Task<IActionResult> Index()
        {
            var movieContext = _context.UsersMovies.Include(u => u.Movie).Include(u => u.Users);
            return View(await movieContext.ToListAsync());
        }

        // GET: Admin/UsersMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsersMovies == null)
            {
                return NotFound();
            }

            var usersMovie = await _context.UsersMovies
                .Include(u => u.Movie)
                .Include(u => u.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersMovie == null)
            {
                return NotFound();
            }

            return View(usersMovie);
        }

        // GET: Admin/UsersMovies/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId");
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "UsersId");
            return View();
        }

        // POST: Admin/UsersMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,UsersId,Commment,Vote,Viewingtime,Id")] UsersMovie usersMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", usersMovie.MovieId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "UsersId", usersMovie.UsersId);
            return View(usersMovie);
        }

        // GET: Admin/UsersMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsersMovies == null)
            {
                return NotFound();
            }

            var usersMovie = await _context.UsersMovies.FindAsync(id);
            if (usersMovie == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", usersMovie.MovieId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "UsersId", usersMovie.UsersId);
            return View(usersMovie);
        }

        // POST: Admin/UsersMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,UsersId,Commment,Vote,Viewingtime,Id")] UsersMovie usersMovie)
        {
            if (id != usersMovie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersMovieExists(usersMovie.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", usersMovie.MovieId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "UsersId", usersMovie.UsersId);
            return View(usersMovie);
        }

        // GET: Admin/UsersMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsersMovies == null)
            {
                return NotFound();
            }

            var usersMovie = await _context.UsersMovies
                .Include(u => u.Movie)
                .Include(u => u.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersMovie == null)
            {
                return NotFound();
            }

            return View(usersMovie);
        }

        // POST: Admin/UsersMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsersMovies == null)
            {
                return Problem("Entity set 'MovieContext.UsersMovies'  is null.");
            }
            var usersMovie = await _context.UsersMovies.FindAsync(id);
            if (usersMovie != null)
            {
                _context.UsersMovies.Remove(usersMovie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersMovieExists(int id)
        {
          return (_context.UsersMovies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
