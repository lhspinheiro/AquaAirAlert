using AquaAirAlert.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AquaAirAlert.Infrastructure.Data;

public class AppDbContext : DbContext       
{
    public DbSet<alert> Alerts { get; set; }
    
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=AquaAirAlert.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}