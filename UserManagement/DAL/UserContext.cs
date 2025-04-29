using Microsoft.EntityFrameworkCore;
using UserManagement.Entities;

namespace UserManagement.DAL
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
