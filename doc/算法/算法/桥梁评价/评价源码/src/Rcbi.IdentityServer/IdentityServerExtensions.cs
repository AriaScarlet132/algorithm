using IdentityServer4.Stores;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rcbi.IdentityServer.Interfaces.Repositories;
using Rcbi.IdentityServer.Interfaces.Services;
using Rcbi.IdentityServer.Repositories.ClientAggregate.InMemory;
using Rcbi.IdentityServer.Repositories.ResourceAggregate.InMemory;
using Rcbi.IdentityServer.Repositories.UserAggregate.InDatabase;
using Rcbi.IdentityServer.Services;


namespace Rcbi.IdentityServer
{
    public static class IdentityServerExtensions
    {
        public static IIdentityServerBuilder AddRcbiIDS(this IIdentityServerBuilder builder, IConfiguration config)
        {
            var option = builder.Services.ConfigurePOCO(config.GetSection("IdentityOptions"), () => new IdentityOptions());
            builder.Services.AddTransient<IUserRepository, UserInDatabaseRepository>();
         
            builder.Services.AddTransient<IResourceRepository, ResourceInMemoryRepository>();
            builder.Services.AddTransient<IClientRepository, ClientInMemoryRepository>();
            builder.Services.AddTransient<IClientStore, ClientInMemoryRepository>();
            builder.Services.AddTransient<IResourceStore, ResourceInMemoryRepository>();
          
            //services
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IPasswordService, PasswordService>();
            //validators
            builder.Services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();

            builder.AddProfileService<ProfileService>();

            return builder;
        }

        public static IIdentityServerBuilder AddRcbiIdentityIDS(this IIdentityServerBuilder builder, IConfigurationRoot config)
        {
            var option = builder.Services.ConfigurePOCO(config.GetSection("IdentityOptions"), () => new IdentityOptions());
            
            builder.AddOperationalStore(options =>
            {
                options.RedisConnectionString = option.Redis;
                options.KeyPrefix = "ids_prefix";
            })
             .AddRedisCaching(options =>
             {
                 options.RedisConnectionString = option.Redis;
             });
             
            builder.AddProfileService<ProfileService>();

            return builder;
        }
    }
}
