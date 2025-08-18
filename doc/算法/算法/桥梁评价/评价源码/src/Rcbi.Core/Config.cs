using System;
using System.IO;

using Microsoft.Extensions.Configuration;

namespace Rcbi.Core
{
    public class ConfigHelper
    {
        private static IConfiguration _configuration { get; set; }

        public static void Init(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetConfig(string name)
        {
            return _configuration.GetSection(name).Value;
        }
    }
}
