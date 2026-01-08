using Journify.core.Entities;
using Journify.infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Journify.infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<DailyJourney> DailyJournies { get; set; }
        public DbSet<Step> Steps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new DailyJourneyConfig());
            modelBuilder.ApplyConfiguration(new StepConfig());
            base.OnModelCreating(modelBuilder);

        }

    }
}
