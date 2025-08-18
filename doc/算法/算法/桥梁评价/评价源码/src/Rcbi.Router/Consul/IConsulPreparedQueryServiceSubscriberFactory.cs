using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Router.Consul
{
    public interface IConsulPreparedQueryServiceSubscriberFactory
    {
        IServiceSubscriber CreateSubscriber(string queryName);
    }
}
