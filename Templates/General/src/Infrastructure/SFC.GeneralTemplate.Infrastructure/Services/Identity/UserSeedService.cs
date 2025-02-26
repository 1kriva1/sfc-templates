using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.GeneralTemplate.Application.Interfaces.Identity;
using SFC.GeneralTemplate.Infrastructure.Extensions;
using SFC.GeneralTemplate.Infrastructure.Settings.RabbitMq;
using SFC.Identity.Messages.Commands;

namespace SFC.GeneralTemplate.Infrastructure.Services.Identity;
public class UserSeedService(IBus bus, IConfiguration configuration) : IUserSeedService
{
    private readonly IBus _bus = bus;
    private readonly IConfiguration _configuration = configuration;

    public async Task SendRequireUsersSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireUsersSeed command = new() { Initiator = settings.Exchanges.GeneralTemplate.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}
