using ATMMachine.Entities;
using Microsoft.EntityFrameworkCore;

namespace ATMMachine.DAL.Context
{
    public class ATMDbContext : DbContext
    {
        public ATMDbContext(DbContextOptions<ATMDbContext> options) : base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ATM> ATMs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ATM>().HasData(
                new ATM { Id = 1, AvailableCash = 100000 },
                new ATM { Id = 2, AvailableCash = 50000 },
                new ATM { Id = 3, AvailableCash = 75000 }
            );
        }

    }
}
