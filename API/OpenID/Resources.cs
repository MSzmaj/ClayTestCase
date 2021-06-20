using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace API.OpenID
{
    internal class Resources
    {
        //public static IEnumerable<IdentityResource> GetIdentityResources()
        //{
        //    return new[]
        //    {
        //        new IdentityResources.OpenId(),
        //        new IdentityResources.Profile(),
        //        new IdentityResource(
        //            name: "role",
        //            userClaims: new[] { "role"}
        //        )
        //    };
        //}

        //public static IEnumerable<ApiResource> GetApiResources()
        //{
        //    return new[]
        //    {
        //        new ApiResource
        //        {
        //            Name = "token",
        //            DisplayName = "Token API",
        //            Description = "Allow the application to access the Token API on your behalf",
        //            Scopes = new List<string> {"token", "profile"},
        //            ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
        //            UserClaims = new List<string> {"token", "profile"}
        //        }
        //    };
        //}

        public static IEnumerable<ApiScope> GetApiScopes =>
            new List<ApiScope> {
                new ApiScope("admin", "Admin Acces")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client {
                    ClientId = "admin_client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("password".Sha256())},
                    AllowedScopes = new List<string> {"admin"}
                }
            };

        //public static List<TestUser> Users =>
        //    new List<TestUser> {
        //        new TestUser {
        //            SubjectId = "1",
        //            Username = "test",
        //            Password = "password",
        //            Claims = new List<Claim> {
        //                new Claim(JwtClaimTypes.Email, "test@test.com"),
        //                new Claim(JwtClaimTypes.Role, "admin")
        //            }
        //    }
        //};
    }
}
