using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.GeneralTemplate.Application.Interfaces.Metadata;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Interfaces.Player;
#endif
using SFC.GeneralTemplate.Domain.Events.Identity;

namespace SFC.GeneralTemplate.Application.Features.Identity.Notifications.CreateUsers;
#if IncludePlayerInfrastructure
public class UsersCreatedNotificationHandler(
    IPlayerSeedService playerSeedService,
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment) : INotificationHandler<UsersCreatedEvent>
{
    private readonly IPlayerSeedService _playerSeedService = playerSeedService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

    public async Task Handle(UsersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Identity, MetadataDomainEnum.User, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Player, MetadataDomainEnum.Player, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                await _playerSeedService.SendRequirePlayersSeedAsync(cancellationToken)
                                        .ConfigureAwait(false);
            }
        }
    }
}
#else
public class UsersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment) : INotificationHandler<UsersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

    public async Task Handle(UsersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Identity, MetadataDomainEnum.User, MetadataTypeEnum.Seed).ConfigureAwait(false);
        }
    }
}
#endif