#if IncludePlayerInfrastructure
namespace SFC.GeneralTemplate.Domain.Entities.Player.General;
public class PlayerStatPoints : BasePlayerEntity
{
    public short Available { get; set; }

    public short Used { get; set; }
}
#endif