using Microsoft.Extensions.Logging;
using Rcbi.Core.Json;
using Rcbi.Core.MqMessages;
using Rcbi.Core.Threading;
using Rebus.Bus;
using System.Threading.Tasks;

namespace Rcbi.MqMessages.RebusCore
{
    public class RebusRabbitMqPublisher : IMqMessagePublisher
    {
        private readonly IBus _bus;

        public ILogger Logger { get; set; }

        public RebusRabbitMqPublisher(IBus bus, ILoggerFactory factory)
        {
            _bus = bus;
            Logger = factory.CreateLogger<RebusRabbitMqPublisher>();
        }

        public void Publish(object mqMessages)
        {
            Logger.LogDebug(mqMessages.GetType().FullName + ":" + mqMessages.ToJsonString());

            AsyncHelper.RunSync(() => _bus.Publish(mqMessages));
        }

        public async Task PublishAsync(object mqMessages)
        {
            Logger.LogDebug(mqMessages.GetType().FullName + ":" + mqMessages.ToJsonString());

            await _bus.Publish(mqMessages);
        }
    }
}
