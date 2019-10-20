using Grpc.Core;
using Hades.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Hades.Server.Services
{
    public class BetaService : Beta.BetaBase
    {
        private readonly ILogger<BetaService> logger;

        public BetaService(ILogger<BetaService> logger)
        {
            this.logger = logger;
        }

        public override Task<AddBetaResponse> AddBeta(AddBetaRequest request, ServerCallContext context)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            logger.LogInformation(request.ToString());

            var response = new AddBetaResponse
            {
                Id = request.Id
            };

            logger.LogInformation(response.ToString());

            return Task.FromResult(response);
        }

        public override Task<GetBetaResponse> GetBeta(GetBetaRequest request, ServerCallContext context)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            logger.LogInformation(request.ToString());

            var response = new GetBetaResponse
            {
                Id = request.Id
            };

            logger.LogInformation(response.ToString());

            return Task.FromResult(response);
        }
    }
}
