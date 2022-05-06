namespace TrevisanLucaProvaSituazionale.Domain;

public class Cinema
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }    
    public IEnumerable<CinemaHall>? CinemaHalls { get; set; }
    public decimal CalculateGross()
    { throw new NotImplementedException(); }
}