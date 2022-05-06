namespace TrevisanLucaProvaSituazionale.Domain;

public class Spectator
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }
    public int? TicketId { get; set; }
    public int? CinemaHallId { get; set; }

    public bool IsAdult
    {
        get { return DateOfBirth.AddYears(18) > DateTime.Now; }
    }
    
    //sconti
}