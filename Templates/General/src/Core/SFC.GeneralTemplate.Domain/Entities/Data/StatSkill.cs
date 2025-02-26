#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Common;

namespace SFC.GeneralTemplate.Domain.Entities.Data;
public class StatSkill : EnumDataEntity<StatSkillEnum>
{
    public StatSkill() : base() { }

    public StatSkill(StatSkillEnum enumType) : base(enumType) { }

    public ICollection<StatType> Types { get; init; } = [];
}
#endif