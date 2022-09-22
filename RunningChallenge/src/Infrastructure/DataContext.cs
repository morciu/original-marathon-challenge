using Domain.Models;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Marathon> Marathons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new MarathonConfiguration());

            /*modelBuilder.Entity<Marathon>()
                .HasMany(x => x.Members);
            modelBuilder.Entity<User>()
                .HasMany(x => x.Activities);
            modelBuilder.Entity<Activity>()
                .Property(x => x.Distance)
                .HasPrecision(18, 6);
            modelBuilder.Entity<Activity>()
                .HasOne(x => x.User)
                .WithMany(x => x.Activities)
                .HasForeignKey(x => x.UserId);*/
        }

    }
}
