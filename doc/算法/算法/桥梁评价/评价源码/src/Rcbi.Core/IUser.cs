using System.Collections.Generic;
using System.Security.Claims;

namespace Rcbi.Core
{
    public interface IUser
    {
        string Id { get; }
        string Name { get; }
        IEnumerable<Claim> Claims { get; }
    }
}
