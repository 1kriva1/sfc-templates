using SFC.GeneralTemplate.Messages.Models;
using SFC.GeneralTemplate.Messages.Models.Data;

namespace SFC.GeneralTemplate.Messages.Commands.Data;
public record InitializeData
{
#if IncludePlayerInfrastructure
    public IEnumerable<DataValue> FootballPositions { get; init; } = [];

    public IEnumerable<DataValue> GameStyles { get; init; } = [];

    public IEnumerable<DataValue> StatCategories { get; init; } = [];

    public IEnumerable<DataValue> StatSkills { get; init; } = [];

    public IEnumerable<StatTypeDataValue> StatTypes { get; init; } = [];

    public IEnumerable<DataValue> WorkingFoots { get; init; } = [];
#endif

#if IncludeTeamInfrastructure
    public IEnumerable<DataValue> Shirts { get; init; } = [];
#endif
}
