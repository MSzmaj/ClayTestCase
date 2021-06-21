using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using API.OpenID;

namespace API.AppStart
{
    public static class OpenIdConfigurator
    {
        public static void ConfigureIdentityServer(IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    //options.Authority = "https://localhost:5001";
                    options.Authority = "https://claytestcase.azurewebsites.net"
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "admin");
                });
            });

            services.AddIdentityServer()
                .AddInMemoryClients(Resources.Clients)
                .AddInMemoryApiScopes(Resources.GetApiScopes)
                .AddDeveloperSigningCredential();
        }
    }
}
