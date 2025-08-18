using Rcbi.Router.Consul;
using Rcbi.Router.Throttle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Router
{
    public interface IServiceSubscriberFactory
    {
        IPollingServiceSubscriber CreateSubscriber(string serviceName);

        IPollingServiceSubscriber CreateSubscriber(string serviceName, ConsulSubscriberOptions consulOptions,
            ThrottleSubscriberOptions throttleOptions);
    }
}
