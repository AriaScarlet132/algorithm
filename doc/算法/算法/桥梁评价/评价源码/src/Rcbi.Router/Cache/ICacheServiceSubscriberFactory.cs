using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Router.Cache
{
    public interface ICacheServiceSubscriberFactory
    {
        IPollingServiceSubscriber CreateSubscriber(IServiceSubscriber serviceSubscriber);
    }
}
