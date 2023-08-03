using Microsoft.Extensions.DependencyInjection;
using Ocelot.Provider.Nacos.NacosClient.V2;
using System;
using Xunit;

namespace Ocelot.Provider.Nacos.Test
{
    public class NacosClientTest : IClassFixture<NacosFixture>
    {
        private readonly IServiceProvider _serviceProvider;

        public NacosClientTest(NacosFixture fixture)
        {
            _serviceProvider = fixture._Host.Services.GetRequiredService<IServiceProvider>();
        }

        [Fact]
        public async void TestClient()
        { 
            RegSvcBgTask regSvcBgTask = _serviceProvider.GetRequiredService<RegSvcBgTask>();
            await regSvcBgTask.StartAsync(default);
            Console.ReadLine();
        }
    }
}
