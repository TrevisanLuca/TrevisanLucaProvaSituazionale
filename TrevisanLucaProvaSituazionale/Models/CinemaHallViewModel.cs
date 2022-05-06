namespace TrevisanLucaProvaSituazionale.Models;

using Microsoft.AspNetCore.Mvc.Rendering;
using TrevisanLucaProvaSituazionale.Domain;

public class CinemaHallViewModel
{

    public IEnumerable<SelectListItem>? Cinemas { get; set; }
    public CinemaHall CinemaHall {get;set;}
    public CinemaHallViewModel()
    {

    }
    public CinemaHallViewModel(IEnumerable<Cinema> cinemas, CinemaHall cinemaHall)
    {
        CinemaHall = cinemaHall;
        Cinemas = cinemas.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
    }
}