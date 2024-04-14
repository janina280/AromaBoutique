using DataBaseLayout;
using Perfume.Repositories;
using Perfume.Repositories.Interfaces;

namespace Perfume;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataLayout(configuration);

        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IShoppingCartPerfumeRepository, ShoppingCartPerfumeRepository>();
        return services;
    }
}