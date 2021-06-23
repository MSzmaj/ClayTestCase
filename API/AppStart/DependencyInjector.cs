using Microsoft.Extensions.DependencyInjection;
using Application.Services.Interfaces;
using Application.Services;
using Domain.Repositories;
using Infratructure.Repositories;
using Common.Config;
using Application.Validators.Interfaces;
using Application.Validators;

namespace API.AppStart
{
    public static class DependencyInjector
    {
        public static void ConfigureDependencies(IServiceCollection services)
        {
            services.AddSingleton<IAppConfig, AppConfig>();
            ConfigureRepositories(services);
            ConfigureValidators(services);
            ConfigureServices(services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ILockService, LockService>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IUserService, UserService>();
        }

        private static void ConfigureValidators(IServiceCollection services) {
            services.AddTransient<ITokenValidator, TokenValidator>();
            services.AddTransient<ILockValidator, LockValidator>();
            services.AddTransient<ILogValidator, LogValidator>();
            services.AddTransient<IUserValidator, UserValidator>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddTransient<ILockRepository, LockRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}