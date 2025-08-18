using Rcbi.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rcbi.Router
{
    public interface ILoadBalancer
    {
        Task<RegistryInformation> Endpoint(CancellationToken ct = default(CancellationToken));
    }
}
