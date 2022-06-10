namespace Catalog.Api.Configuration
{
    public static class SettingConfiguration
    {
        public static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDatabaseSettings>(configuration.GetSection(key: nameof(MongoDatabaseSettings)));
            return services;
        }
    }
}
