using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Snp.ePort.Api.Configurations
{
    public static class CachingConfigure
    {
        public static void AddCaching(this IServiceCollection services, IWebHostEnvironment hostContext, IConfiguration config)
        {
            switch(config["CacheMode"])
            {
                case "SQL":
                    services.AddDistributedSqlServerCache(options =>
                    {
                        options.ConnectionString = config["DistCache_ConnectionString"];
                        options.SchemaName = "dbo";
                        options.TableName = "TestCache";
                    });
                    break;

                case "Redis":
                    services.AddStackExchangeRedisCache(options =>
                    {
                        options.Configuration = "172.16.50.189:7001,172.16.50.189:7002,172.16.50.189:7003,172.16.50.189:7004,172.16.50.189:7005,172.16.50.189:7006,";
                    });
                    break;

                default:
                    services.AddDistributedMemoryCache();
                    break;
            }

        }
    }
}
