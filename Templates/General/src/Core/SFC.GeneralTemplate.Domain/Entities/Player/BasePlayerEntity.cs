#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Player;
public abstract class BasePlayerEntity : BaseEntity<long>
{
    public Player Player { get; set; } = null!;
}
#endif