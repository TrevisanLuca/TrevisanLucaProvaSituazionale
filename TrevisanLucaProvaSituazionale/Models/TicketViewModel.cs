using Microsoft.AspNetCore.Mvc.Rendering;
using TrevisanLucaProvaSituazionale.Domain;

namespace TrevisanLucaProvaSituazionale.Models;

public class TicketViewModel
{
    public IEnumerable<SelectListItem>? CinemaHall { get; set; }
    public Ticket Ticket { get; set; }
    public TicketViewModel()
    {

    }
    public TicketViewModel(IEnumerable<CinemaHall> cinemaHall, Ticket ticket)
    {
        Ticket = ticket;
        CinemaHall = cinemaHall.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = $"{c.Name}: {c.Film?.Title}" });
    }
}