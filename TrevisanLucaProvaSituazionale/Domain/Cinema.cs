namespace TrevisanLucaProvaSituazionale.Domain;

public class Cinema
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public IEnumerable<CinemaHall>? CinemaHalls { get; set; }
    public Cinema()
    {

    }
    public Cinema(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public decimal CalculateGross()
    {
        var result = 0m;

        if (CinemaHalls is not null)
            foreach (var cinemaHall in CinemaHalls)                
                        result += cinemaHall.CalculateGross();

        return result;
    }
}