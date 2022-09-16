using Microsoft.Extensions.DependencyInjection;
using CoffeeStore.DataAccess.Repositories;
using CoffeeStore.DataAccess.Repositories.Implementation;

namespace CoffeeStore.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductTypesRepository, ProductTypesRepository>();
            services.AddScoped<IProductPropertiesRepository, ProductPropertiesRepository>();
            services.AddScoped<IEnumValuesRepository, EnumValuesRepository>();
            services.AddScoped<IProductPropertyValuesRepository, ProductPropertyValuesRepository>();
        }
    }
}
