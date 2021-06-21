using System.Collections.Generic;
using IdentityServer4.Models;

namespace API.OpenID
{
    internal class Resources
    {
        public static IEnumerable<ApiScope> GetApiScopes =>
            new List<ApiScope> {
                new ApiScope("admin", "Admin Acces"),
                new ApiScope("user", "User Acces")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client {
                    ClientId = "admin_client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("password".Sha256())},
                    AllowedScopes = new List<string> {"admin"}
                },
                new Client {
                    ClientId = "user_client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("password".Sha256())},
                    AllowedScopes = new List<string> {"user"}
                }
            };
    }
}
