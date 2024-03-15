using EF_TestFixes.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_TestFixes;

public class MyDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Person<int>> Persons { get; set; }
    public DbSet<Person<string>> PersonsString { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Type> Types { get; set; }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //modelBuilder.Entity<Order>()
    //    .HasOne(o => o.Customer)
    //    .WithMany(c => c.Orders)
    //    .HasForeignKey(o => o.CustomerId);
    //modelBuilder.Entity<Order>()
    //    .HasOne(o => o.Product)
    //    .WithMany(p => p.Orders)
    //    .HasForeignKey(o => o.ProductId);
    //modelBuilder.Entity<Invoice>()
    //    .HasOne(i => i.Customer)
    //    .WithMany(c => c.Invoices)
    //    .HasForeignKey(i => i.CustomerId);
    //modelBuilder.Entity<Person<int>>().HasOne(p => p.Order).WithMany(o => o.Persons).HasForeignKey(p => p.Name);
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}

public class Entity<TId>
{
    public TId Id { get; set; }
}