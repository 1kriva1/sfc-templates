#if IncludePlayerInfrastructure
namespace SFC.GeneralTemplate.Domain.Entities.Player;
public class PlayerStatPoints : BasePlayerEntity
{
    public short Available { get; set; }

    public short Used { get; set; }
}
#endif