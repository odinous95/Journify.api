using Journify.core.Entities;
using Microsoft.EntityFrameworkCore;
using StepManagment.infrastructure.Configurations;

namespace StepManagment.infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<DailyJourney> DailyJournies { get; set; }
        public DbSet<Step> Steps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new DailyJourneyConfig());
            modelBuilder.ApplyConfiguration(new StepConfig());
            base.OnModelCreating(modelBuilder);

        }

    }
}
