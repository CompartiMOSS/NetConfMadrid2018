using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace ISA.Credentials
{
    public static class Config
    {



        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
    {
        new TestUser
        {
            SubjectId = "1",
            Username = "adrian",
            Password = "elrealmadridcampeondeeuropaunavezmas"
        },
        new TestUser
        {
            SubjectId = "2",
            Username = "parrita",
            Password = "thesame"
        }
    };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                  new IdentityResources.OpenId(),
                  new IdentityResources.Profile(),
                  new IdentityResources.Email(),
                  new IdentityResource {
                      Name = "Read",
                      UserClaims = new List<string> {"Read"}
                  },
                  new IdentityResource {
                      Name = "ReadWrite",
                      UserClaims = new List<string> {"ReadWrite"}
                  }
              };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {

            return new List<ApiResource> {
            new ApiResource {
                Name = "netConfAPI",
                DisplayName = "Net Conf API",
                Description = "API para todos los accesos a la Web de la Net Conf",
                UserClaims = new List<string> {"Read","ReadWrite"},
                ApiSecrets = new List<Secret> {new Secret("scopeSecret".Sha256())},
                Scopes = new List<Scope> {
                    new Scope("teamAPI"),
                    new Scope("playerAPI")
                }
            }
        };

        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> {
                new Client {
                    ClientId = "openIdnetConf",
                    ClientName = "Example Implicit Client Application",
                           ClientSecrets = new List<Secret> { new Secret("superSecretPassword".Sha256()) },
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    AlwaysSendClientClaims=true,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "ReadWrite",
                        "teamAPI",
                        "playerAPI"
                    },
                    RedirectUris = new List<string> {"https://localhost:44392/signin-oidc"},
                    PostLogoutRedirectUris = new List<string> { "https://localhost:44392/" }
                }
            };
        }
    }
}
