#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;
using SFC.GeneralTemplate.Application.Features.Team.Data.Common.Dto;

namespace SFC.GeneralTemplate.Application.Features.Team.Data.Commands.Reset;
public class ResetTeamDataCommand : Request
{
    public override RequestId RequestId { get => RequestId.ResetTeamData; }

    public IEnumerable<TeamPlayerStatusDto> TeamPlayerStatuses { get; init; } = [];
}
#endif