#if IncludePlayerInfrastructure
using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Domain.Entities.Player.General;

namespace SFC.GeneralTemplate.Application.Common.Dto.Player.General;

public record PlayerAvailabilityDto : IMapFromReverse<PlayerAvailability>
{
    public TimeSpan? From { get; set; }

    public TimeSpan? To { get; set; }

    public IEnumerable<DayOfWeek> Days { get; set; } = [];

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerAvailabilityDto, PlayerAvailability>()
               .ReverseMap()
               .IgnoreAllNonExisting();
    }
}
#endif