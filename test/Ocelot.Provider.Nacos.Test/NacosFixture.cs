using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ocelot.Provider.Nacos.NacosClient.V2;
using System;

namespace Ocelot.Provider.Nacos.Test
{
    public class NacosFixture : IDisposable
    {
        public IHost _Host { get; }

        public NacosFixture()
        {
            _Host = GetHost();
        }

        private IHost GetHost()
        {
            IHost host = Host.CreateDefaultBuilder()
                             .ConfigureServices((_, services) =>
                             {
                                 services.AddNacosAspNet(Init());
                             })
                            .Build();

            return host;
        }

        private IConfiguration Init()
        {
            var config = new ConfigurationBuilder()
                       .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                       .AddJsonFile("appsettings.json", true, true)
                       .AddJsonFile("appsettings.Development.json", true, true).Build();
            return config;
        }

        public void Dispose()
        {

        }
    }
}
