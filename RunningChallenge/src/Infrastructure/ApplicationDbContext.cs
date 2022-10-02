using Domain.Models;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Marathon> Marathons { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new MarathonConfiguration());
            modelBuilder.ApplyConfiguration(new InvitationConfiguration());

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