using TrevisanLucaProvaSituazionale.Exceptions;

namespace TrevisanLucaProvaSituazionale.Domain;

public class CinemaHall
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int CinemaId { get; set; }
    public Cinema? Cinema { get; set; }

    [Required, Range(0, int.MaxValue)]
    public int MaxSpectators { get; set; }
    public IEnumerable<Spectator>? Spectators { get; set; }
    public IEnumerable<Ticket>? Tickets { get; set; }
    public int? FilmId { get; set; }
    public Film? Film { get; set; }
    public CinemaHall()
    {

    }
    public CinemaHall(int id, string name, int cinemaId, int maxSpectators, int? filmId)
    {
        Id = id;
        Name = name;
        CinemaId = cinemaId;
        MaxSpectators = maxSpectators;
        FilmId = filmId;
    }

    public void EmptyRoom()
    { throw new NotImplementedException(); }
    public bool AddSpectator(Spectator spectator)
    {
        if (spectator.IsUnderage && Film.Genre == "Horror")
            throw new FilmVietatoException();
        if (Spectators.Count() == MaxSpectators)
            throw new SalaAlCompletoException();
        return true;
    }
    public decimal CalculateGross()
    {
        var result = 0m;

        if (Tickets is not null)
            foreach (var ticket in Tickets)            
                result += ticket.Price;            

        return result;
    }
}