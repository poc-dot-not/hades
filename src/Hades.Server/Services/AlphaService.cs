using Grpc.Core;
using Hades.Shared;
using Microsoft.Extensions.Logging;
using System;
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

        public override Task<AddAlphaResponse> AddAlpha(AddAlphaRequest request, ServerCallContext context)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            logger.LogInformation(request.ToString());

            var response = new AddAlphaResponse
            {
                Id = request.Id
            };

            logger.LogInformation(response.ToString());

            return Task.FromResult(response);
        }

        public override Task<GetAlphaResponse> GetAlpha(GetAlphaRequest request, ServerCallContext context)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            logger.LogInformation(request.ToString());

            var response = new GetAlphaResponse
            {
                Id = request.Id
            };

            logger.LogInformation(response.ToString());

            return Task.FromResult(response);
        }
    }
}
