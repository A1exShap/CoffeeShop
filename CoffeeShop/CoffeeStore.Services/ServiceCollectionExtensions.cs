using Microsoft.Extensions.DependencyInjection;
using CoffeeStore.Services.Implementation;
using CoffeeStore.DataAccess;

namespace CoffeeStore.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IPropertiesService, PropertiesService>();

            services.RegisterRepositories();
        }
    }
}
