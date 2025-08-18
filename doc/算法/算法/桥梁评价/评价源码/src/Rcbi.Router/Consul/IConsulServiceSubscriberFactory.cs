using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Router.Consul
{
    public interface IConsulServiceSubscriberFactory
    {
        IServiceSubscriber CreateSubscriber(string serviceName, ConsulSubscriberOptions consulOptions, bool watch);
    }
}
