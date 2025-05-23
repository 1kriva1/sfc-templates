#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Api.Infrastructure.Models.Common;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Common.Dto.Player.General;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.Player.Result;

/// <summary>
/// Player's **availability** model (when player is available to play).
/// </summary>
public class PlayerAvailabilityModel :
    RangeLimitModel<TimeSpan?>,
    IMapFromReverse<PlayerAvailabilityDto>
{
    /// <summary>
    /// Days of week.
    /// </summary>
    public IEnumerable<DayOfWeek> Days { get; set; } = [];
}
#endif