#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Data;
public class Shirt : EnumDataEntity<ShirtEnum>
{
    public Shirt() : base() { }

    public Shirt(ShirtEnum enumType) : base(enumType) { }
}
#endif