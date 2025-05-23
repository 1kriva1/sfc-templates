#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;
using SFC.GeneralTemplate.Application.Common.Dto.Team.General;

namespace SFC.GeneralTemplate.Application.Features.Team.General.Commands.Update;
public class UpdateTeamCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateTeam; }

    public TeamDto Team { get; set; } = null!;
}
#endif