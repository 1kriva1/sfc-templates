#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Domain.Entities.Team.Data;

namespace SFC.GeneralTemplate.Domain.Events.Team.Data;

public class TeamDataResetedEvent(IEnumerable<TeamPlayerStatus> teamPlayerStatuses) : BaseEvent
{
    public IEnumerable<TeamPlayerStatus> TeamPlayerStatuses { get; } = teamPlayerStatuses;
}
#endif