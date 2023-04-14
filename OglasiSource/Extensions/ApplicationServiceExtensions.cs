using OglasiSource.Infrastructure.Data;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Interfaces.Repositories;
using OglasiSource.Infrastructure.Data.Repository;
using OglasiSource.Infrastructure.Services;

namespace OglasiSource.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped(typeof(IReadGenericRepository<>), (typeof(ReadGenericRepository<>)));
            services.AddScoped<IDataProtection, DataProtection>();
            services.AddScoped<IImgurUploadService, ImgurUploadService>();

            return services;
        }
    }
}

