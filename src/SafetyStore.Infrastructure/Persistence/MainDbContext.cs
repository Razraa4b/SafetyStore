using Microsoft.EntityFrameworkCore;
using SafetyStore.Domain.Entities;

namespace SafetyStore.Infrastructure.Persistance
{
    public class MainDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public MainDbContext(DbContextOptions options) : base(options) { }
    }
}
