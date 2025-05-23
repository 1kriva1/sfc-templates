#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Common.Dto.Player.Filters;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.Player.Find.Filters;

/// <summary>
/// Get players **profile filter** model.
/// </summary>
public class PlayerProfileFilterModel : IMapTo<PlayerProfileFilterDto>
{
    /// <summary>
    /// General profile.
    /// </summary>
    public PlayerGeneralProfileFilterModel General { get; set; } = default!;

    /// <summary>
    /// Football profile.
    /// </summary>
    public PlayerFootballProfileFilterModel Football { get; set; } = default!;
}
#endif