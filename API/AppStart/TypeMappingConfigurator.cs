using Application.TypeMappings;
using Microsoft.Extensions.DependencyInjection;

namespace API.AppStart
{
    public static class TypeMappingConfigurator
    {
        public static void ConfigureTypeMappings(IServiceCollection services)
        {
            ConfigureDomainToApplicationTypeMappings(services);
        }

        private static void ConfigureDomainToApplicationTypeMappings (IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TokenToTokenModel));
        }
    }
}
