using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Activity> Activities => Set<Activity>();
        public DbSet<Marathon> Marathon => Set<Marathon>();
    }
}
