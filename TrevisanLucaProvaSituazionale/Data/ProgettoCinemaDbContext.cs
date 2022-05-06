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
           
        base.OnModelCreating(modelBuilder);
    }
}