using Microsoft.EntityFrameworkCore;

namespace DataApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        public DbSet<ShipConfirm> ShipConfirms { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderHeader>().ToTable("OrderHeader"); 
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail"); 

            modelBuilder.Entity<ShipConfirm>()
                .HasKey(c => new { c.clientID, c.orderID });
            modelBuilder.Entity<OrderHeader>()
                .HasMany(l => l.OrderDetail);
            modelBuilder.Entity<OrderHeader>()
                .HasKey(c => new { c.clientID, c.orderID });
            modelBuilder.Entity<OrderDetail>()
                .HasKey(c => new { c.clientID, c.orderID, c.orderLine });
        }

    }
}
