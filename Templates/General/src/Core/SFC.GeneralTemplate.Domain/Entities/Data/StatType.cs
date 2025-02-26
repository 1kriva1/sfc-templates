#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Data;
public class StatType : EnumDataEntity<StatTypeEnum>
{
    public StatType() : base() { }

    public StatType(StatTypeEnum enumType) : base(enumType) { }

    public StatCategoryEnum CategoryId { get; set; }

    public StatSkillEnum SkillId { get; set; }
}
#endif