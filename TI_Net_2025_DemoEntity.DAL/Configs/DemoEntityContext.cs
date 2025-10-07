using Microsoft.EntityFrameworkCore;
using TI_Net_2025_DemoEntity.DL.Entities;

public class DemoEntityContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public DemoEntityContext(DbContextOptions<DemoEntityContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoEntityContext).Assembly);
    }
}