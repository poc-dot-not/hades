using Hades.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hades.Client
{
    public interface IHadesClient : IDisposable
    {
        Task<AddAlphaResponse> AddAlphaAsync(AddAlphaRequest request, CancellationToken cancellationToken = default);

        Task<AddBetaResponse> AddBetaAsync(AddBetaRequest request, CancellationToken cancellationToken = default);

        Task<GetAlphaResponse> GetAlphaAsync(GetAlphaRequest request, CancellationToken cancellationToken = default);

        Task<GetBetaResponse> GetBetaAsync(GetBetaRequest request, CancellationToken cancellationToken = default);

        IAsyncEnumerable<BetaDto> GetBetaStreamAsync(GetBetaRequest request, CancellationToken cancellationToken = default);
    }
}
