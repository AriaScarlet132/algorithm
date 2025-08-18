using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using static IdentityServer4.IdentityServerConstants;

namespace Rcbi.IdentityServer.Repositories.ClientAggregate.InMemory
{
    public class InMemoryClients
    {
        public static IEnumerable<Client> Clients = new List<Client>
        {
            new Client
            {
                    ClientId = "rcbi",
                    ClientSecrets = { new Secret("rcbi_model_2020".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        StandardScopes.OfflineAccess,
                        "open_api"
                    },
                    AllowOfflineAccess = true

            },
            new Client
            {
                    ClientId = "cjxx",
                    ClientSecrets = { new Secret("cjxx_model_2020".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        StandardScopes.OfflineAccess,
                        "open_api"
                    },
                    AllowOfflineAccess = true

            }
        };
    }
}
