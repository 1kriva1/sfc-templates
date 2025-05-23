#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Domain.Entities.Team.Player;

namespace SFC.GeneralTemplate.Domain.Events.Team.Player;
public class TeamPlayersCreatedEvent(IEnumerable<TeamPlayer> teamPlayers) : BaseEvent
{
    public IEnumerable<TeamPlayer> TeamPlayers { get; } = teamPlayers;
}
#endif