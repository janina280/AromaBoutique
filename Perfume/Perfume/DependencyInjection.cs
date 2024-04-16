using DataBaseLayout;
using Perfume.Repositories;
using Perfume.Repositories.Interfaces;
using Perfume.Services;
using Perfume.Services.Interfaces;

namespace Perfume;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataLayout(configuration);

        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IDeliveryRepository, DeliveryRepository>();
        services.AddScoped<IFeatureRepository, FeatureRepository>();
        services.AddScoped<IPerfumeCategoryRepository, PerfumeCategoryRepository>();
        services.AddScoped<IPerfumeImageRepository, PerfumeImageRepository>();
        services.AddScoped<IPerfumeRepository, PerfumeRepository>();
        services.AddScoped<IPromotionRepository, PromotionRepository>();
        services.AddScoped<IReviewConversationRepository, ReviewConversationRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IShoppingCartPerfumeRepository, ShoppingCartPerfumeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWishRepository, WishRepository>();

        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IPerfumeDetailsService, PerfumeDetailsService>();
        services.AddScoped<IPerfumeService, PerfumeService>();

        return services;
    }
}