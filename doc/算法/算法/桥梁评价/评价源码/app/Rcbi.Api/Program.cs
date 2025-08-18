using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Internals;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Rcbi.iisp.Business.ModelMsgEntity;

namespace Rcbi.Api
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateWebHost(args).Run();
        }

        public static IWebHost CreateWebHost(string[] args) =>
               WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, builder) =>
                {
                    builder
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("hosting.json", true, false)
                    .AddApollo(builder.Build().GetSection("apollo"))
                    .AddDefault()
                    .AddNamespace("rcbi.configuration");
                }).UseStartup<Startup>().Build();


    }
}
