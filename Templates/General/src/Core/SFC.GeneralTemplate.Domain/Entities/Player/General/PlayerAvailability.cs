#if IncludePlayerInfrastructure
namespace SFC.GeneralTemplate.Domain.Entities.Player.General;
public class PlayerAvailability : BasePlayerEntity
{
    public TimeSpan? From { get; set; }

    public TimeSpan? To { get; set; }

    public ICollection<PlayerAvailableDay> Days { get; init; } = [];
}
#endif