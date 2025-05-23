#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Messages.Models.Data;

namespace SFC.GeneralTemplate.Messages.Commands.Team.Data;
public record InitializeData
{
    public IEnumerable<DataValue> TeamPlayerStatuses { get; init; } = [];
}
#endif