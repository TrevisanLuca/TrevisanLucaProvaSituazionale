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
    public int? FilmId { get; set; }
    public Film? Film { get; set; }
    public void EmptyRoom() 
    { throw new NotImplementedException(); }
    public void AddSpectator()
    { throw new NotImplementedException(); }
    public decimal CalculateGross()
    { throw new NotImplementedException(); }
}