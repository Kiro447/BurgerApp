using Microsoft.EntityFrameworkCore;
using BurgerApp.Domain.Models;
using BurgerApp.DataAccess.DataSeed;

namespace BurgerApp.DataAccess.Data;

public class BurgerAppDbContext : DbContext
{
    public BurgerAppDbContext(DbContextOptions<BurgerAppDbContext> options) : base(options){}

    public DbSet<Order> Orders { get; set; }
    public DbSet<Burger> Burgers { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Burger>()
            .HasMany(x => x.OrderBurgers)
            .WithOne(x => x.Burger)
            .HasForeignKey(x => x.BurgerId);

        modelBuilder.Entity<Burger>()
            .HasMany(x => x.BurgerLocations)
            .WithOne(x => x.Burger)
            .HasForeignKey(x => x.BurgerId);

        modelBuilder.Entity<Order>()
            .HasMany(x => x.OrderBurgers)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId);

        modelBuilder.Entity<Location>()
            .HasMany(x => x.LocationBurgers)
            .WithOne(x => x.Location)
            .HasForeignKey(x => x.LocationId);


        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var dataSeeder = new BurgerAppDataSeed(this);
        dataSeeder.SeedData();
    }
}
