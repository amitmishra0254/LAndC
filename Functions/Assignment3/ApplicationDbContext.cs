using Microsoft.EntityFrameworkCore;

namespace Assignment3
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
