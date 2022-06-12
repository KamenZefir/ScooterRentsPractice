using Microsoft.EntityFrameworkCore;

namespace ScooterRents.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        public DbSet<Scooters> Scooters { get; set; }
    }
}
