using Microsoft.EntityFrameworkCore;
using Owners.Domain.Entities;

namespace Infrastructure.Persistance;

public class OwnerDbContext : DbContext
{
    public OwnerDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Owner> Owners => Set<Owner>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OwnerDbContext).Assembly);
    }
}
