#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Data;
public class FootballPosition : EnumDataEntity<FootballPositionEnum>
{
    public FootballPosition() : base() { }

    public FootballPosition(FootballPositionEnum enumType) : base(enumType) { }
}
#endif
