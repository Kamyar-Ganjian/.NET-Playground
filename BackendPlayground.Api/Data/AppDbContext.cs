using BackendPlayground.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendPlayground.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .HasIndex(customer => customer.Email)
            .IsUnique();
    }
}