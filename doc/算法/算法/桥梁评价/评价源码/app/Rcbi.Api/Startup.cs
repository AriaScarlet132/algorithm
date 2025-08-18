using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;
using Exceptionless;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.IdentityModel.Logging;

using Rcbi.IdentityServer;
using Microsoft.Extensions.Logging;
using Rcbi.Api.Middleware;
using Rcbi.Api.Filter;
using Rcbi.Entity.Domain;
using Rcbi.Core;
using Rcbi.Exceptionless;
using Rcbi.Exceptionless.Extensions;
using Rcbi.iisp.Business;

namespace Rcbi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IHostingEnvironment Environment { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigHelper.Init(Configuration);

            var cert = new X509Certificate2(Path.Combine(Environment.ContentRootPath, "rcbi.pfx"), "idsrv3test");

            services.AddIdentityServer()
                .AddSigningCredential(cert)
                .AddRcbiIDS(Configuration);

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Audience = "open_api";
                    options.Authority = Configuration.GetSection("AppSetting:HostUrl").Value;
                    options.RequireHttpsMetadata = false;
                });

            services.AddRcbiExceptionless();

            services.AddMvc(options => {
                options.Filters.Add(typeof(DataValidFilterAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options =>
            {
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            }
        );

            IdentityModelEventSource.ShowPII = true;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "swagger")),
                RequestPath = "/swagger"
            }); ;

            ExceptionlessClient.Default.Configuration.ApiKey = Configuration.GetSection("Exceptionless:ApiKey").Value;
            ExceptionlessClient.Default.Configuration.ServerUrl = Configuration.GetSection("Exceptionless:ServerUrl").Value;

            app.UseExceptionless();
            //异常记录
            app.UseMiddleware<RCBIExceptionHandlerMiddleware>();

            app.UseIdentityServer();
            app.UseMiddleware<HttpContextMiddleware>();
            app.UseMvc();
        }
    }
}
