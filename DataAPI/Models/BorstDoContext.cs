using Microsoft.EntityFrameworkCore;

namespace BorstDo.Models
{
    public class BorstDoContext : DbContext
    {
        public BorstDoContext(DbContextOptions<BorstDoContext> options) : base (options)
        {

        }

        public DbSet<BorstDoItem> BorstItems { get; set; }
    }
}
