#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Data;
public class GameStyle : EnumDataEntity<GameStyleEnum>
{
    public GameStyle() : base() { }

    public GameStyle(GameStyleEnum enumType) : base(enumType) { }
}
#endif
