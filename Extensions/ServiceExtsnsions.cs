using Velox_Url.Services;
using Velox_Url.Services.Interfaces;

namespace Velox_Url.Extensions
{
    public static class ServiceExtsnsions
    {
        public static IServiceCollection AddVeloxUrlServices(this IServiceCollection services)
        {
            services.AddScoped<IShortUrlService, ShortUrlService>();
            return services;
        }
    }
}
