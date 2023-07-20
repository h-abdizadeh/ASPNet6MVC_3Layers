using CarShop.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Database.Context;
public class DatabaseContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlServer(@"Data source=.\SQLEXPRESS;
                                Initial Catalog=CarShopDb;
                                    Integrated Security=SSPI");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }


    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }
    public DbSet<Factor> Factors { get; set; }
    public DbSet<FactorDetail> FactorDetails { get; set; }
}
