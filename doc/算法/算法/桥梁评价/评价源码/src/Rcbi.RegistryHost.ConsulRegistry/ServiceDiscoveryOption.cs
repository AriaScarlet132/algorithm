﻿using Rcbi.RegistryHost.ConsulRegistry;

namespace Rcbi.RegistryHost.ConsulRegistry
{
    public class ConsulServiceDiscoveryOption
    {
        public string ServiceName { get; set; }

        public string Version { get; set; }

        public ConsulRegistryHostConfiguration Consul { get; set; }

        public string HealthCheckTemplate { get; set; }

        public string[] Endpoints { get; set; }
    }
}
