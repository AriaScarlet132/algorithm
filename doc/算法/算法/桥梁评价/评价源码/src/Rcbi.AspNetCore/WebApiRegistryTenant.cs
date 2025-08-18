using Rcbi.Core;
using System;

namespace Rcbi.WebApi
{
    public class WebApiRegistryTenant : IRegistryTenant
    {
        public Uri Uri { get; }

        public WebApiRegistryTenant(Uri uri)
        {
            Uri = uri;
        }
    }
}
