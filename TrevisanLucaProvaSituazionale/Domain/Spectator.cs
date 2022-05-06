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