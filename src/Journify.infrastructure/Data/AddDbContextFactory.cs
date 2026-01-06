using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Journify.infrastructure.Data
{
    public static class AddDbContextFactory
    {
        public static void AddPostgreSqlDb(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString,
                providerOptions => providerOptions.EnableRetryOnFailure()));
        }
    }
}
