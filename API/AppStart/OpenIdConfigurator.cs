using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using API.OpenID;
using Microsoft.IdentityModel.Tokens;
using Common;
namespace API.AppStart
{
    public static class OpenIdConfigurator
    {
        public static void ConfigureIdentityServer(IServiceCollection services)
        {
            services.AddAuthentication(Constants.Auth.Bearer)
                .AddIdentityServerAuthentication(Constants.Auth.Bearer, options =>
                {
                    //options.Authority = "https://localhost:5001";
                    options.Authority = "https://claytestcase.azurewebsites.net";
                    options.RequireHttpsMetadata = false;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "admin");
                });
                options.AddPolicy("User", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "user");
                });
            });

            services.AddIdentityServer()
                .AddInMemoryClients(Resources.Clients)
                .AddInMemoryApiScopes(Resources.GetApiScopes)
                .AddDeveloperSigningCredential();
        }
    }
}
