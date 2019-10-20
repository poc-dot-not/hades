using Hades.Client;
using Hades.IntegrationTests.Setup;
using Hades.Shared;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Hades.IntegrationTests.Client
{
    public class AlphaTests : IClassFixture<ClientFixture>
    {
        private readonly IHadesClient client;

        public AlphaTests(ClientFixture fixture)
        {
            client = fixture.Client;
        }

        [Fact]
        public async Task AddAlpha_Success()
        {
            var request = new AddAlphaRequest
            {
                Id = Guid.NewGuid().ToString()
            };

            var response = await client.AddAlphaAsync(request);

            Assert.NotNull(response);
            Assert.Equal(request.Id, response.Id);
        }

        [Fact]
        public async Task GetAlpha_Success()
        {
            var request = new GetAlphaRequest
            {
                Id = Guid.NewGuid().ToString()
            };

            var response = await client.GetAlphaAsync(request);

            Assert.NotNull(response);
            Assert.Equal(request.Id, response.Id);
        }
    }
}
