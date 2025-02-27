﻿#if IncludePlayerInfrastructure
using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.GeneralTemplate.Application.Interfaces.Metadata;
using SFC.GeneralTemplate.Domain.Events.Player;

namespace SFC.GeneralTemplate.Application.Features.Player.Notifications.PlayersCreated;
public class PlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment) : INotificationHandler<PlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

    public async Task Handle(PlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Player, MetadataTypeEnum.Seed).ConfigureAwait(false);
        }
    }
}
#endif