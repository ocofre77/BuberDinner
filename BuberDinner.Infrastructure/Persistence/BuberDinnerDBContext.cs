using System.Data.Entity;
using BuberDinner.Domain.Aggregates;

namespace BuberDinner.Infrastructure.Persistence;

public class BuberDinnerDBContext: DbContext
{
    public BuberDinnerDBContext()
    {

    }

    //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    // }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    // }
    // //entities
    public DbSet<Dinner> Dinners { get; set; }
    
}