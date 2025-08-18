namespace Rcbi.Core
{
    public interface IRegistryHost : IManageServiceInstances, 
        IManageHealthChecks,
        IResolveServiceInstances
    {
    }
}
