using Hades.Client;
using Hades.IntegrationTests.Setup;
using Hades.Shared;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Hades.IntegrationTests.Client
{
    public class BetaTests : IClassFixture<ClientFixture>
    {
        private readonly IHadesClient client;

        public BetaTests(ClientFixture fixture)
        {
            client = fixture.Client;
        }

        [Fact]
        public async Task AddBeta_Success()
        {
            var request = new AddBetaRequest
            {
                Id = Guid.NewGuid().ToString()
            };

            var response = await client.AddBetaAsync(request);

            Assert.NotNull(response);
            Assert.Equal(request.Id, response.Id);
        }

        [Fact]
        public async Task GetBeta_Success()
        {
            var request = new GetBetaRequest
            {
                Id = Guid.NewGuid().ToString()
            };

            var response = await client.GetBetaAsync(request);

            Assert.NotNull(response);
            Assert.Equal(request.Id, response.Id);
        }
    }
}
