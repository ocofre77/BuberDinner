using System.Data.Entity;
//using System.Data.Entity. .Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence;

public class BubberDinnerDBContext: DbContext
{
    public BubberDinnerDBContext()
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