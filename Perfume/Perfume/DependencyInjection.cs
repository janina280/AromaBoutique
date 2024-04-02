using DataBaseLayout;
using Perfume.Repositories;

namespace Perfume;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataLayout(configuration);

        services.AddScoped<IBrandRepository, BrandRepository>();
        return services;
    }
}