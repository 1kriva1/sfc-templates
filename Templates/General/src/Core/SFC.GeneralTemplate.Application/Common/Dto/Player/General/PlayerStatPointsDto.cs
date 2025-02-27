#if IncludePlayerInfrastructure
using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Domain.Entities.Player;

namespace SFC.GeneralTemplate.Application.Common.Dto.Player.General;

public record PlayerStatPointsDto : IMapFromReverse<PlayerStatPoints>
{
    public int Available { get; set; }

    public int Used { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerStatPointsDto, PlayerStatPoints>()
               .ReverseMap()
               .IgnoreAllNonExisting();
    }
}
#endif