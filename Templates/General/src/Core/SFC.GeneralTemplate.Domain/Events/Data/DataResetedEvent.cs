using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Domain.Entities.Data;

namespace SFC.GeneralTemplate.Domain.Events.Data;

#if IncludePlayerInfrastructure
public class DataResetedEvent(
    IEnumerable<FootballPosition> footballPositions,
    GameStyle[] gameStyles,
    WorkingFoot[] workingFoots,
    StatType[] statTypes
    ) : BaseEvent
{
    public IEnumerable<FootballPosition> FootballPositions { get; } = footballPositions;

    public IEnumerable<GameStyle> GameStyles { get; } = gameStyles;

    public IEnumerable<WorkingFoot> WorkingFoots { get; } = workingFoots;

    public IEnumerable<StatType> StatTypes { get; } = statTypes;
}
#else
public class DataResetedEvent() : BaseEvent { }
#endif
