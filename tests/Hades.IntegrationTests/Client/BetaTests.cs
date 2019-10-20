using Hades.Client;
using Hades.IntegrationTests.Setup;
using Hades.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hades.IntegrationTests.Client
{
    public class BetaTests : IClassFixture<ClientFixture>
    {
        private const int DataCount = 10;

        private readonly IHadesClient client;

        public BetaTests(ClientFixture fixture)
        {
            client = fixture.Client;
        }

        [Fact]
        public async Task AddBeta_Success()
        {
            var data = GenerateData();
            var request = new AddBetaRequest
            {
                Id = Guid.NewGuid().ToString(),
                Data = { data }
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
            Assert.Equal(DataCount, response.Data.Count);
        }

        private static BetaDto[] GenerateData()
        {
            var data = Enumerable
                .Range(1, DataCount)
                .Select(x => new BetaDto
                {
                    Id = x,
                    Data = $"record_{x}"
                })
                .ToArray();

            return data;
        }
    }
}
