#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Data;
public class StatCategory : EnumDataEntity<StatCategoryEnum>
{
    public StatCategory() : base() { }

    public StatCategory(StatCategoryEnum enumType) : base(enumType) { }

    public ICollection<StatType> Types { get; init; } = [];
}
#endif