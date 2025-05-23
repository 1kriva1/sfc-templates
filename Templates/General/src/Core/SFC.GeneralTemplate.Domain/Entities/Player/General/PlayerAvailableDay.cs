#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Player.General;
public class PlayerAvailableDay : BaseEntity<long>
{
    public PlayerAvailability Availability { get; set; } = null!;

    public DayOfWeek Day { get; set; }
}
#endif