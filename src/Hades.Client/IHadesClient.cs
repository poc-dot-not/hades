using Hades.Shared;
using System;
using System.Threading.Tasks;

namespace Hades.Client
{
    public interface IHadesClient : IDisposable
    {
        Task<AddAlphaResponse> AddAlphaAsync(AddAlphaRequest request);

        Task<AddBetaResponse> AddBetaAsync(AddBetaRequest request);

        Task<GetAlphaResponse> GetAlphaAsync(GetAlphaRequest request);

        Task<GetBetaResponse> GetBetaAsync(GetBetaRequest request);
    }
}
