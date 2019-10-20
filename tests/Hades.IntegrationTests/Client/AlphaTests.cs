using Hades.Client;
using Hades.IntegrationTests.Setup;
using Hades.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hades.IntegrationTests.Client
{
    public class AlphaTests : IClassFixture<ClientFixture>
    {
        private const int DataCount = 10;

        private readonly IHadesClient client;

        public AlphaTests(ClientFixture fixture)
        {
            client = fixture.Client;
        }

        [Fact]
        public async Task AddAlpha_Success()
        {
            var data = GenerateData();
            var request = new AddAlphaRequest
            {
                Id = Guid.NewGuid().ToString(),
                Data = { data }
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
            Assert.Equal(DataCount, response.Data.Count);
        }

        private static string[] GenerateData()
        {
            var data = Enumerable
                .Range(1, DataCount)
                .Select(x => $"record_{x}")
                .ToArray();

            return data;
        }
    }
}
