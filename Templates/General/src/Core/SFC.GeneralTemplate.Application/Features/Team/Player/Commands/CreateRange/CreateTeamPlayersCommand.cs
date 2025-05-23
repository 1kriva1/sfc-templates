#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Common.Enums;
using SFC.GeneralTemplate.Application.Features.Common.Base;
using SFC.GeneralTemplate.Application.Common.Dto.Team.Player;

namespace SFC.GeneralTemplate.Application.Features.Team.Player.Commands.CreateRange;
public class CreateTeamPlayersCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayers; }

    public IEnumerable<TeamPlayerDto> TeamPlayers { get; set; } = null!;
}
#endif