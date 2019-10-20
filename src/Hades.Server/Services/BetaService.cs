using Grpc.Core;
using Hades.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
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

        public override async Task<AddBetaResponse> AddBeta(AddBetaRequest request, ServerCallContext context)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            logger.LogInformation(request.ToString());

            var response = new AddBetaResponse
            {
                Id = request.Id
            };

            await Task.Delay(100);

            logger.LogInformation(response.ToString());

            return response;
        }

        public override async Task<GetBetaResponse> GetBeta(GetBetaRequest request, ServerCallContext context)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            logger.LogInformation(request.ToString());

            var data = Enumerable
                .Range(1, 10)
                .Select(x => new BetaDto
                {
                    Id = x,
                    Data = $"record_{x}"
                })
                .ToArray();

            var response = new GetBetaResponse
            {
                Id = request.Id,
                Data = { data }
            };

            await Task.Delay(50);

            logger.LogInformation(response.ToString());

            return response;
        }

        public override async Task GetBetaStream(GetBetaRequest request, IServerStreamWriter<BetaDto> responseStream, ServerCallContext context)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            logger.LogInformation(request.ToString());

            var iteration = 1;
            while (!context.CancellationToken.IsCancellationRequested && iteration <= 10)
            {
                await Task.Delay(100);

                var response = new BetaDto
                {
                    Id = iteration,
                    Data = $"record_{iteration}"
                };

                logger.LogInformation(response.ToString());

                await responseStream.WriteAsync(response);

                iteration++;
            }

            if (context.CancellationToken.IsCancellationRequested)
            {
                 logger.LogInformation("The request canceled by the client!");
            }
        }
    }
}
