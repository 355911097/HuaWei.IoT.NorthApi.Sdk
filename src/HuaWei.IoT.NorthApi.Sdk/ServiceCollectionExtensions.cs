using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HuaWei.IoT.NorthApi.Sdk
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加华为物联网SDK
        /// </summary>
        /// <param name="services"></param>
        /// <param name="environmentName"></param>
        /// <returns></returns>
        public static IServiceCollection AddHuaWeiIoTSdk(this IServiceCollection services, string environmentName)
        {
            var str = Path.Combine(AppContext.BaseDirectory, "config");
            var cfg = new ConfigurationBuilder().SetBasePath(str).AddJsonFile("iot.json", true, true).Build();
            var options = cfg.Get<NorthApiOptions>();

            if (options != null)
            {
                services.AddSingleton(options);
                services.AddSingleton<INorthApiClient, NorthApiClient>();
            }

            return services;
        }
    }
}
