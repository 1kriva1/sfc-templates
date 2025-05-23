#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;
using SFC.GeneralTemplate.Application.Common.Dto.Team.Player;

namespace SFC.GeneralTemplate.Application.Features.Team.Player.Commands.Create;
public class CreateTeamPlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayer; }

    public required TeamPlayerDto TeamPlayer { get; set; }
}
#endif