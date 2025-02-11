using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Domain;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Geolocation> Geolocations { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=meubanco;Username=meuusuario;Password=minhasenha");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Address)
            .WithOne()
            .HasForeignKey<Address>(a => a.Id);

        modelBuilder.Entity<Address>()
            .HasOne(a => a.Geolocation)
            .WithOne()
            .HasForeignKey<Geolocation>(g => g.Id);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Rating)
            .WithOne()
            .HasForeignKey<Rating>(r => r.Id);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany()
            .HasForeignKey("UserId");

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey("OrderId");

        modelBuilder.Entity<Item>()
            .HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey("ProductId");
    }
}
