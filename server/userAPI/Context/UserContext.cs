using Microsoft.EntityFrameworkCore;
using userAPI.Models;

namespace userAPI.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
    }
}
