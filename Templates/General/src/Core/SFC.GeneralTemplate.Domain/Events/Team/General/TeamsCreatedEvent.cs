#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Events.Team.General;
public class TeamsCreatedEvent(IEnumerable<TeamEntity> teams) : BaseEvent
{
    public IEnumerable<TeamEntity> Teams { get; } = teams;
}
#endif