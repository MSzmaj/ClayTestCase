using Microsoft.Extensions.DependencyInjection;
using Application.Services.Interfaces;
using Application.Services;
using Domain.Repositories;
using Infratructure.Repositories;

namespace API.AppStart
{
    public static class DependencyInjector
    {
        public static void ConfigureDependencies(IServiceCollection services)
        {
            ConfigureRepositories(services);
            ConfigureServices(services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            //services.AddSingleton<Repository.Common.AppConfig>();
            //services.AddSingleton<Repository.DataAccess.DatabaseContext>();
            services.AddTransient<ITokenRepository, TokenRepository>();
        }
    }
}