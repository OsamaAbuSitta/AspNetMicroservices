using Catalog.Api.Data;
using Catalog.Api.Repositories;


namespace Catalog.Api.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICatalogContext, CatalogContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }

    }
}
