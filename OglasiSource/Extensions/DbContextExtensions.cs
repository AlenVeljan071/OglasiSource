using Microsoft.EntityFrameworkCore;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration config)
        {
           
            services.AddDbContext<DbReadContext>(x => x.UseMySql(config["ConnectionStrings:ReadConnection"], ServerVersion.AutoDetect(config["ConnectionStrings:ReadConnection"])));
            services.AddDbContext<DbWriteContext>(x => x.UseMySql(config["ConnectionStrings:WriteConnection"], ServerVersion.AutoDetect(config["ConnectionStrings:WriteConnection"])));
            return services;
        }
    }
}
