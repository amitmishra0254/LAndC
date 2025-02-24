using Microsoft.EntityFrameworkCore;

namespace CustomerSearch
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public DbSet<Customer> customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
