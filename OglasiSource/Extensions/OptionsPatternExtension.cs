using OglasiSource.Core.Config;


namespace OglasiSource.Api.Extensions

{
    public static class OptionsPatternExtensions
    {
        public static IServiceCollection AddOptionsPattern(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<TokenSettings>(config.GetSection("Token"));
         
            return services;
        }
    }
}
