#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Entities.Data;

namespace SFC.GeneralTemplate.Domain.Entities.Player.General;
public class PlayerStat : BasePlayerEntity
{
    public StatTypeEnum TypeId { get; set; }

    public required StatType Type { get; set; }

    public byte Value { get; set; }
}
#endif