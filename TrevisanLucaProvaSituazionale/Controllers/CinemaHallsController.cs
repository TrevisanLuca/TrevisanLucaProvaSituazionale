#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrevisanLucaProvaSituazionale.Data;
using TrevisanLucaProvaSituazionale.Models;

namespace TrevisanLucaProvaSituazionale.Controllers
{
    public class CinemaHallsController : Controller
    {
        private readonly ProgettoCinemaDbContext _context;

        public CinemaHallsController(ProgettoCinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id is null)
            {
                var cinemas = await _context.CinemaHalls
                    .Include(ch => ch.Film)
                    .Include(ch => ch.Tickets)
                    .ToListAsync();
                var result = cinemas.Select(c => new CinemaHallIndexViewModel(c, c.CalculateGross()));
                return View(result);
            }
            else
            {
                var cinemas = await _context.CinemaHalls
                       .Include(ch => ch.Film)
                       .Include(ch => ch.Tickets)
                       .ToListAsync();
                var result = cinemas.Select(c => new CinemaHallIndexViewModel(c, c.CalculateGross()));
                return View(result);
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaHall = await _context.CinemaHalls.
                Include(ch => ch.Cinema)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cinemaHall == null)
            {
                return NotFound();
            }

            return View(cinemaHall);
        }

        public async Task<IActionResult> Create()
        {
            var cinemas = await _context.Cinemas.ToListAsync();
            var viewModel = new CinemaHallViewModel(cinemas, null);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CinemaHallViewModel cinemaHallViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinemaHallViewModel.CinemaHall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinemaHallViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaHall = await _context.CinemaHalls.FindAsync(id);
            var cinemas = await _context.Cinemas.ToListAsync();
            if (cinemaHall == null)
            {
                return NotFound();
            }
            var viewModel = new CinemaHallViewModel(cinemas, cinemaHall);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CinemaHallViewModel cinemaHallViewModel)
        {
            if (id != cinemaHallViewModel.CinemaHall.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinemaHallViewModel.CinemaHall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinemaHallExists(cinemaHallViewModel.CinemaHall.Id))
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
            return View(cinemaHallViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaHall = await _context.CinemaHalls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaHall == null)
            {
                return NotFound();
            }

            return View(cinemaHall);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaHall = await _context.CinemaHalls.FindAsync(id);
            _context.CinemaHalls.Remove(cinemaHall);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinemaHallExists(int id)
        {
            return _context.CinemaHalls.Any(e => e.Id == id);
        }
    }
}