using Microsoft.EntityFrameworkCore;

namespace Velox_Url.Extensions
{
    public static class DbConnectionExtension
    {
        public static IServiceCollection AddVeloxUrlDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("VeloxDbConString");
            services.AddDbContext<Data.UrlDbContext>(options =>
                options.UseNpgsql(connectionString));
            return services;
        }
    }
}
