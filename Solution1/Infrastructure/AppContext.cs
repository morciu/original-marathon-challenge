using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    internal class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Activity> Activities => Set<Activity>();
        public DbSet<Marathon> Marathon => Set<Marathon>();
    }
}
