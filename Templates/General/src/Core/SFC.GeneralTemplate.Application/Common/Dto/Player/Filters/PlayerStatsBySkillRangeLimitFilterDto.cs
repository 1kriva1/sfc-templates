#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Features.Common.Dto.Common;

namespace SFC.GeneralTemplate.Application.Common.Dto.Player.Filters;
public class PlayerStatsBySkillRangeLimitFilterDto : RangeLimitDto<short?>
{
    public int Skill { get; set; }
}
#endif