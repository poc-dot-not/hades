using Grpc.Net.Client;
using Hades.Shared;
using System.Threading.Tasks;

namespace Hades.Client
{
    public class HadesClient : IHadesClient
    {
        private readonly GrpcChannel channel;

        public HadesClient(string address)
        {
            channel = GrpcChannel.ForAddress(address);
        }

        public async Task<AddAlphaResponse> AddAlphaAsync(AddAlphaRequest request)
        {
            var client = new Alpha.AlphaClient(channel);

            return await client.AddAlphaAsync(request);
        }

        public async Task<AddBetaResponse> AddBetaAsync(AddBetaRequest request)
        {
            var client = new Beta.BetaClient(channel);

            return await client.AddBetaAsync(request);
        }

        public async Task<GetAlphaResponse> GetAlphaAsync(GetAlphaRequest request)
        {
            var client = new Alpha.AlphaClient(channel);

            return await client.GetAlphaAsync(request);
        }

        public async Task<GetBetaResponse> GetBetaAsync(GetBetaRequest request)
        {
            var client = new Beta.BetaClient(channel);

            return await client.GetBetaAsync(request);
        }

        public void Dispose()
        {
            channel?.Dispose();
        }
    }
}
