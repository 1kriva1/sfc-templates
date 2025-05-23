#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Common.Dto.Player.Filters;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.Player.Find.Filters;

/// <summary>
/// Get players filter model.
/// </summary>
public class PlayerFilterModel : IMapTo<PlayerFilterDto>
{
    /// <summary>
    /// Profile filter model.
    /// </summary>
    public PlayerProfileFilterModel Profile { get; set; } = default!;

    /// <summary>
    /// Stats filter model.
    /// </summary>
    public PlayerStatsFilterModel Stats { get; set; } = default!;
}
#endif