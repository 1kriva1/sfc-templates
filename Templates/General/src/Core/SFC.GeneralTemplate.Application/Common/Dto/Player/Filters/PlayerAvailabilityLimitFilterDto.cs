#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Features.Common.Dto.Common;

namespace SFC.GeneralTemplate.Application.Common.Dto.Player.Filters;
public class PlayerAvailabilityLimitFilterDto : RangeLimitDto<TimeSpan?>
{
    public IEnumerable<DayOfWeek> Days { get; set; } = [];
}
#endif