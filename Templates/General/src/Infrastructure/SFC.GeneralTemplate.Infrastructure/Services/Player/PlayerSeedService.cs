#if IncludePlayerInfrastructure
using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.GeneralTemplate.Infrastructure.Extensions;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq;
using SFC.Player.Messages.Commands.Player;
using SFC.GeneralTemplate.Application.Interfaces.Player;

namespace SFC.GeneralTemplate.Infrastructure.Services.Player;
public class PlayerSeedService(IConfiguration configuration, IBus bus) : IPlayerSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequirePlayersSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequirePlayersSeed command = new() { Initiator = settings.Exchanges.GeneralTemplate.Key };

        await _bus.Send<RequirePlayersSeed>(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}
#endif