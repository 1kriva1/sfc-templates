#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.GeneralTemplate.Application.Interfaces.Metadata;
using SFC.GeneralTemplate.Domain.Events.Team.Player;
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.General;

namespace SFC.GeneralTemplate.Application.Features.Team.Player.Notifications.TeamPlayersCreated;
public class TeamPlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    IGeneralTemplateSeedService generalTemplateSeedService) : INotificationHandler<TeamPlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IGeneralTemplateSeedService _generalTemplateSeedService = generalTemplateSeedService;

    public async Task Handle(TeamPlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Team, MetadataDomainEnum.TeamPlayer, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.GeneralTemplate, MetadataDomainEnum.GeneralTemplate, MetadataTypeEnum.Seed).ConfigureAwait(false))
            {
                await _generalTemplateSeedService.SeedGeneralTemplateMultipleAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
#endif