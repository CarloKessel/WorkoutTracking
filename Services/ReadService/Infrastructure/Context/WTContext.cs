using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class WTContext : DbContext
{
    public WTContext(DbContextOptions<WTContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Workout>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }

    public DbSet<Workout> Workouts { get; set; }
}
