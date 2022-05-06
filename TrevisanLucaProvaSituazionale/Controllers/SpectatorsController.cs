#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrevisanLucaProvaSituazionale.Data;
using TrevisanLucaProvaSituazionale.Domain;

namespace TrevisanLucaProvaSituazionale.Controllers
{
    public class SpectatorsController : Controller
    {
        private readonly ProgettoCinemaDbContext _context;

        public SpectatorsController(ProgettoCinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Spectators.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spectator = await _context.Spectators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spectator == null)
            {
                return NotFound();
            }

            return View(spectator);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,DateOfBirth")] Spectator spectator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spectator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return RedirectToAction("Ticket/Create", new {Id = spectator.Id});
            return View(spectator);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spectator = await _context.Spectators.FindAsync(id);
            if (spectator == null)
            {
                return NotFound();
            }
            return View(spectator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,DateOfBirth,TicketId")] Spectator spectator)
        {
            if (id != spectator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spectator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpectatorExists(spectator.Id))
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
            return View(spectator);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spectator = await _context.Spectators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spectator == null)
            {
                return NotFound();
            }

            return View(spectator);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spectator = await _context.Spectators.FindAsync(id);
            _context.Spectators.Remove(spectator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpectatorExists(int id)
        {
            return _context.Spectators.Any(e => e.Id == id);
        }
    }
}