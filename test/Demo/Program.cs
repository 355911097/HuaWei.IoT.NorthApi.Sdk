using System.Threading.Tasks;
using HuaWei.IoT.NorthApi.Sdk;
using NetModular.Lib.Host.Generic;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new HostBuilder().Run<Startup>(args, (services, env) =>
                {
                    services.AddHuaWeiIoTSdk(env.EnvironmentName);
                });
        }
    }
}
