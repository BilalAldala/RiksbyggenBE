using Microsoft.EntityFrameworkCore;

namespace FastighetsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        
        public DbSet<Apartment> Apartments { get; set; }

    }
}