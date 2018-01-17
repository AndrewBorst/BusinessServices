using Microsoft.EntityFrameworkCore;

namespace DataApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        public DbSet<ShipConfirm> ShipConfirms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShipConfirm>()
                .HasKey(c => new { c.ClientID, c.OrderID });
        }

    }
}
