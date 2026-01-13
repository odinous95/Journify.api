using Journify.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace StepManagment.infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Steps { get; set; }


    }
}
