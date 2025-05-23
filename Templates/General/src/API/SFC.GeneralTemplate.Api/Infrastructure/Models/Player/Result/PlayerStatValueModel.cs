#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Common.Dto.Player.General;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.Player.Result;

/// <summary>
/// Player stat value model.
/// </summary>
public class PlayerStatValueModel : IMapFromReverse<PlayerStatValueDto>
{
    /// <summary>
    /// Type of stat
    /// </summary>
    public int Type { get; set; } = default!;

    /// <summary>
    /// Stat value.
    /// </summary>
    public byte Value { get; set; }
}
#endif