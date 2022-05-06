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
    public Ticket? Ticket { get; set; }
    public int? CinemaHallId { get; set; }
    public CinemaHall? CinemaHall { get; set; }
    public Spectator()
    {

    }
    public Spectator(int id, string name, string surname, DateTime dateOfBirth, int? ticketId, int? cinemaHallId)
    {
        Id = id;
        Name = name;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        TicketId = ticketId;
        CinemaHallId = cinemaHallId;
    }
    public bool IsUnderage
    {
        get { return DateOfBirth.AddYears(18) > DateTime.Now.Date; }
    }
    public bool IsSenior
    {
        get { return DateOfBirth.AddYears(70) <= DateTime.Now.Date; }
    }
    public bool IsChildren
    {
        get { return DateOfBirth.AddYears(5) > DateTime.Now.Date; }
    }
}