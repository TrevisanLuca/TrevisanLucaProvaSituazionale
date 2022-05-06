namespace TrevisanLucaProvaSituazionale.Models;

using Microsoft.AspNetCore.Mvc.Rendering;
using TrevisanLucaProvaSituazionale.Domain;

public class CinemaHallViewModel
{

    public IEnumerable<SelectListItem>? Cinemas { get; set; }
    public CinemaHall CinemaHall {get;set;}
    public IEnumerable<SelectListItem>? Movies { get; set; }
    public CinemaHallViewModel()
    {

    }
    public CinemaHallViewModel(IEnumerable<Cinema> cinemas, CinemaHall cinemaHall, IEnumerable<Film> films)
    {
        CinemaHall = cinemaHall;
        Cinemas = cinemas.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
        Movies = films.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Title });
    }
}