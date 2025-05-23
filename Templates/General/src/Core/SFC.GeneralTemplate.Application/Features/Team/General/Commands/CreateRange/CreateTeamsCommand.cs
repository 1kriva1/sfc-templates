#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;
using SFC.GeneralTemplate.Application.Common.Dto.Team.General;

namespace SFC.GeneralTemplate.Application.Features.Team.General.Commands.CreateRange;
public class CreateTeamsCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateTeams; }

    public IEnumerable<TeamDto> Teams { get; set; } = null!;
}
#endif