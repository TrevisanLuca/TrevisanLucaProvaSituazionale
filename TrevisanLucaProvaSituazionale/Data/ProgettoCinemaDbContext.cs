namespace TrevisanLucaProvaSituazionale.Data;

using Microsoft.EntityFrameworkCore;
using TrevisanLucaProvaSituazionale.Domain;

public class ProgettoCinemaDbContext : DbContext
{
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<CinemaHall> CinemaHalls { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Spectator> Spectators { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    public ProgettoCinemaDbContext(DbContextOptions<ProgettoCinemaDbContext> options)
        : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .Property(t => t.Price)
            .HasPrecision(8, 2);

        #region seeding
        modelBuilder.Entity<Cinema>()
            .HasData(
            new Cinema(1, "Cinema Quattro Stagioni"),
            new Cinema(2, "Cinema Dante"));

        modelBuilder.Entity<Film>()
            .HasData(
            new Film(1, "Lord of the Rings","Peter Jackson", "New Line Cinema", "Fantasy", 180),
            new Film(2, "The Ring", "Gore Verbinski", "Hiroshi Takahashi", "Horror", 90)
            );

        modelBuilder.Entity<CinemaHall>()
            .HasData(
            new CinemaHall(1, "Primavera", 1, 50, 1),
            new CinemaHall(2, "Estate", 1, 60, 2),
            new CinemaHall(3, "Autunno", 1, 20, 1),
            new CinemaHall(4, "Inverno", 1, 15, 2),
            new CinemaHall(5, "Inferno", 2, 100, 1),
            new CinemaHall(6, "Purgatorio", 2, 150, 2),
            new CinemaHall(7, "Paradiso", 2, 10, 1)
            );

        modelBuilder.Entity<Ticket>()
            .HasData(
            new Ticket(1, 1, 1, 10),
            new Ticket(2, 1, 2, 10),
            new Ticket(3, 6, 1, 10),
            new Ticket(4, 3, 1, 10)
            );

        modelBuilder.Entity<Spectator>()
            .HasData(
            new Spectator(1,"Mario", "Bianchi", DateTime.Parse("1950-03-12"), 1, 1),
            new Spectator(2,"Giuseppe", "Rossi", DateTime.Parse("1988-10-05"), 2, 1),
            new Spectator(3,"Miriam", "Verdi", DateTime.Parse("1998-05-06"), 3, 6),
            new Spectator(4,"Giovanna", "Neri", DateTime.Parse("2007-01-12"), 4, 3)
            );
        #endregion

        base.OnModelCreating(modelBuilder);
    }
}