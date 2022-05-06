namespace TrevisanLucaProvaSituazionale.Domain;

public class Ticket
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int CinemaHallId { get; set; }

    [Required, Range(0, int.MaxValue)]
    public int Position { get; set; }

    [Required, Range(0, int.MaxValue)] //decimal.maxvalue is not an accepted overload
    public decimal Price { get; set; }
    public Spectator? Spectator { get; set; }
    //todo : riduzioni
}