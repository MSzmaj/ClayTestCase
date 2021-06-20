using System.Collections.Generic;
using IdentityServer4.Models;

namespace API.OAuth
{
    internal class Clients
    {
        public static IEnumerable<IdentityServer4.Models.Client> Get()
        {
            return new List<IdentityServer4.Models.Client>
            {
                new IdentityServer4.Models.Client {
                    ClientId = "oauthClient",
                    ClientName = "Example client application using client credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())},
                    AllowedScopes = new List<string> {"token.get"}
                }
            };
        }
    }
}
