#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Common.Dto.Player.General;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.Player.Result;

/// <summary>
/// Player **profile** model for get players request.
/// </summary>
public class PlayerProfileModel : IMapFrom<PlayerProfileDto>
{
    /// <summary>
    /// General profile.
    /// </summary>
    public PlayerGeneralProfileModel General { get; set; } = null!;

    /// <summary>
    /// Football profile.
    /// </summary>
    public PlayerFootballProfileModel Football { get; set; } = null!;
}
#endif