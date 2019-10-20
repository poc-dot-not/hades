using Hades.Client;
using Microsoft.Extensions.Configuration;
using System;

namespace Hades.IntegrationTests.Setup
{
    public class ClientFixture : IDisposable
    {
        public ClientFixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var address = configuration.GetSection("Server:Url").Get<string>();

            Client = new HadesClient(address);
        }

        public IHadesClient Client { get; }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
