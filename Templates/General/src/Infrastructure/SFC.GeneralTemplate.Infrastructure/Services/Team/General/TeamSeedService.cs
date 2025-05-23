#if IncludeTeamInfrastructure
using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Team.Messages.Commands.Team;
using SFC.Team.Messages.Commands.Team.General;
using SFC.GeneralTemplate.Application.Interfaces.Team.General;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq;
using SFC.GeneralTemplate.Infrastructure.Extensions;

namespace SFC.GeneralTemplate.Infrastructure.Services.Team.General;
public class TeamSeedService(IConfiguration configuration, IBus bus) : ITeamSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireTeamsSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireTeamsSeed command = new() { Initiator = settings.Exchanges.GeneralTemplate.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}
#endif