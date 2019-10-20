using Grpc.Core;
using Grpc.Net.Client;
using Hades.Shared;
using System.Collections.Generic;
using System.Threading;
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

        public async Task<AddAlphaResponse> AddAlphaAsync(AddAlphaRequest request, CancellationToken cancellationToken = default)
        {
            var client = new Alpha.AlphaClient(channel);

            return await client.AddAlphaAsync(request, cancellationToken: cancellationToken);
        }

        public async Task<AddBetaResponse> AddBetaAsync(AddBetaRequest request, CancellationToken cancellationToken = default)
        {
            var client = new Beta.BetaClient(channel);

            return await client.AddBetaAsync(request, cancellationToken: cancellationToken);
        }

        public async Task<GetAlphaResponse> GetAlphaAsync(GetAlphaRequest request, CancellationToken cancellationToken = default)
        {
            var client = new Alpha.AlphaClient(channel);

            return await client.GetAlphaAsync(request, cancellationToken: cancellationToken);
        }

        public async Task<GetBetaResponse> GetBetaAsync(GetBetaRequest request, CancellationToken cancellationToken = default)
        {
            var client = new Beta.BetaClient(channel);

            return await client.GetBetaAsync(request, cancellationToken: cancellationToken);
        }

        public async IAsyncEnumerable<BetaDto> GetBetaStreamAsync(GetBetaRequest request, CancellationToken cancellationToken = default)
        {
            var client = new Beta.BetaClient(channel);

            using (var stream = client.GetBetaStream(request, cancellationToken: cancellationToken))
            {
                await foreach (var dto in stream.ResponseStream.ReadAllAsync(cancellationToken))
                {
                    yield return dto;
                }
            }
        }

        public void Dispose()
        {
            channel?.Dispose();
        }
    }
}
