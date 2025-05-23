#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.GeneralTemplate.Application.Interfaces.Team.Player;
using SFC.Team.Messages.Commands.Team.Player;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq;
using SFC.GeneralTemplate.Infrastructure.Extensions;

namespace SFC.GeneralTemplate.Infrastructure.Services.Team.Player;
public class TeamPlayerSeedService(IConfiguration configuration, IBus bus) : ITeamPlayerSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireTeamPlayersSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireTeamPlayersSeed command = new() { Initiator = settings.Exchanges.GeneralTemplate.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}
#endif