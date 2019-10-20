using Grpc.Core;
using Hades.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hades.Server.Services
{
    public class AlphaService : Alpha.AlphaBase
    {
        private readonly ILogger<AlphaService> logger;

        public AlphaService(ILogger<AlphaService> logger)
        {
            this.logger = logger;
        }

        public override async Task<AddAlphaResponse> AddAlpha(AddAlphaRequest request, ServerCallContext context)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            logger.LogInformation(request.ToString());

            var response = new AddAlphaResponse
            {
                Id = request.Id
            };

            await Task.Delay(100);

            logger.LogInformation(response.ToString());

            return response;
        }

        public override async Task<GetAlphaResponse> GetAlpha(GetAlphaRequest request, ServerCallContext context)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            logger.LogInformation(request.ToString());

            var data = Enumerable
                .Range(1, 10)
                .Select(x => $"record_{x}")
                .ToArray();

            var response = new GetAlphaResponse
            {
                Id = request.Id,
                Data = { data }
            };

            await Task.Delay(50);

            logger.LogInformation(response.ToString());

            return response;
        }
    }
}
