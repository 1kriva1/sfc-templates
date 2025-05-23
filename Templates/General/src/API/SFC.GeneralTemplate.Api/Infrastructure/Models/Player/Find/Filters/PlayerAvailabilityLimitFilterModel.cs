#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Api.Infrastructure.Models.Common;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Common.Dto.Player.Filters;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.Player.Find.Filters;

/// <summary>
/// Get players **availability filter** model.
/// </summary>
public class PlayerAvailabilityLimitFilterModel :
    RangeLimitModel<TimeSpan?>,
    IMapTo<PlayerAvailabilityLimitFilterDto>
{
    /// <summary>
    /// Day of week.
    /// </summary>
    public IEnumerable<int> Days { get; set; } = default!;
}
#endif