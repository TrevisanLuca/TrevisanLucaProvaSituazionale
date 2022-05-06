namespace TrevisanLucaProvaSituazionale.Domain;

public class Film
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    public string Producer { get; set; }

    [Required]
    public string Genre { get; set; }

    [Required, Range(0, int.MaxValue)]
    public int Length { get; set; } //minutes
}