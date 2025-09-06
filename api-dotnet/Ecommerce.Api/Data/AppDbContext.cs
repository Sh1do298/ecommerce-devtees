using Microsoft.EntityFrameworkCore;
using Ecommerce.Api.Models;

namespace Ecommerce.Api.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder b) {
        // índices e precisões importantes para MySQL
        b.Entity<Product>()
            .HasIndex(p => p.Name);

        b.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(10, 2);   // evita double/float no MySQL
    }
}
