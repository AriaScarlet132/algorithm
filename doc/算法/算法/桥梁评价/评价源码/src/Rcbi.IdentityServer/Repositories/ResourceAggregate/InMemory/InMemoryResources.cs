using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Rcbi.IdentityServer.Repositories.ResourceAggregate.InMemory
{
    public class InMemoryResources
    {

        //API Resources
        public static IEnumerable<ApiResource> ApiResources = new List<ApiResource>
        {
            new ApiResource("open_api", "My API")
            {
                ApiSecrets =   {   new Secret("rcbi_model_2020".Sha256()), new Secret("cjxx_model_2020".Sha256())  },
            }
        };

        //Identity Resources
        public static IEnumerable<IdentityResource> IdentityResources = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };
    }
}