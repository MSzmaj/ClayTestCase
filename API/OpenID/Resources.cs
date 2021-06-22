using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

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
                    AlwaysIncludeUserClaimsInIdToken = true,
                    ClientSecrets = new List<Secret> {new Secret("password".Sha256())},
                    AllowedScopes = new List<string> {"admin"}
                },
                new Client {
                    ClientId = "user_client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    ClientSecrets = new List<Secret> {new Secret("password".Sha256())},
                    AllowedScopes = new List<string> {
                        "user"
                    }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "test3",
                    Password = "password",

                    Claims = new []
                    {
                        new Claim("name", "Test3"),
                        new Claim("email", "Test3@Test.com")
                    }
                }
            };
    }
}
