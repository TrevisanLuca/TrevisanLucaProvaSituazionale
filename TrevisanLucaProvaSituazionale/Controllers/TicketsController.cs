#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using TrevisanLucaProvaSituazionale.Data;
using TrevisanLucaProvaSituazionale.Domain;
using TrevisanLucaProvaSituazionale.Models;
using TrevisanLucaProvaSituazionale.Options;

namespace TrevisanLucaProvaSituazionale.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ProgettoCinemaDbContext _context;
        private readonly TicketOptions _options;

        public TicketsController(ProgettoCinemaDbContext context, IOptions<TicketOptions> options)
        {
            _context = context;
            _options = options.Value;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return NotFound();


            var ticket = await _context.Tickets.
                Include(t => t.CinemaHall)
                .ThenInclude(ch => ch.Film)
                .Include(t => t.Spectator)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ticket is null)
                return NotFound();


            return View(ticket);
        }

        public async Task<IActionResult> Create(int? Id)
        {
            if (Id is null)
            {
                return View("Error");
            }

            var spectaror = await _context.Spectators.FirstOrDefaultAsync(s => s.Id == Id);
            if (spectaror is null)
                return View("Error");

            var newTicket = new Ticket() { Spectator = spectaror };
            var cinemaHalls = await _context.CinemaHalls
                                    .Include(ch => ch.Film)
                                    .ToListAsync();
            var ticketViewModel = new TicketViewModel(cinemaHalls, newTicket);
            return View(ticketViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketViewModel ticketViewModel)
        {
            if (!ModelState.IsValid)
                return View(ticketViewModel);

            var spectator = await _context.Spectators.FirstOrDefaultAsync(s => s.Id == ticketViewModel.Ticket.Spectator.Id);
            if (spectator is null)
                return NotFound();
            ticketViewModel.Ticket.Spectator = spectator;

            var cinemaHall = await _context.CinemaHalls
                                           .Include(ch => ch.Film)
                                           .Include(ch => ch.Spectators)
                                           .FirstOrDefaultAsync(ch => ch.Id == ticketViewModel.Ticket.CinemaHallId);
            if (cinemaHall is null)
                return NotFound();
            ticketViewModel.Ticket.CinemaHall = cinemaHall;


            var price = _options.Price;
            if (ticketViewModel.Ticket.Spectator.IsSenior)
                price *= 0.9m;
            if (ticketViewModel.Ticket.Spectator.IsChildren)
                price *= 0.5m;
            ticketViewModel.Ticket.Price = price;

            try
            {
                if (!cinemaHall.AddSpectator(spectator))
                    return View("Error");                                  

                    _context.Add(ticketViewModel.Ticket);
                    await _context.SaveChangesAsync();

                spectator.TicketId = ticketViewModel.Ticket.Id;
                _context.Spectators.Update(spectator);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));                
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id is null)
        //    {
        //        return NotFound();
        //    }

        //    var ticket = await _context.Tickets.FindAsync(id);
        //    if (ticket is null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ticket);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,CinemaHallId,Position,Price")] Ticket ticket)
        //{
        //    if (id != ticket.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(ticket);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TicketExists(ticket.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(ticket);
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ticket = await _context.Tickets
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ticket);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ticket = await _context.Tickets.FindAsync(id);
        //    _context.Tickets.Remove(ticket);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
