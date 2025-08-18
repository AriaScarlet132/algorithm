using Microsoft.Extensions.DependencyInjection;
using Rcbi.Core.MqMessages;
using Rcbi.MqMessages.RebusCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.MqMessages
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMqMessages(this IServiceCollection services 
           )
        {
            services.AddSingleton<IMqMessagePublisher, RebusRabbitMqPublisher>();
            return services;
        }
    }
}
