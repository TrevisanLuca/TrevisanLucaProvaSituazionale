namespace TrevisanLucaProvaSituazionale.Domain;

public class Ticket
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int Position { get; set; }

    [Required, Range(0, int.MaxValue)] //decimal.maxvalue is not an accepted overload
    public decimal Price { get; set; }
    //riduzioni
}