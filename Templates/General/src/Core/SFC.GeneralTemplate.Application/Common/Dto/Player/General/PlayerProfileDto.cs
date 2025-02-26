#if IncludePlayerInfrastructure
using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;

namespace SFC.GeneralTemplate.Application.Common.Dto.Player.General;
public class PlayerProfileDto : IMapFrom<PlayerEntity>
{
    public PlayerGeneralProfileDto General { get; set; } = null!;

    public PlayerFootballProfileDto Football { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerEntity, PlayerProfileDto>()
               .ForMember(p => p.General, d => d.MapFrom(z => z))
               .ForMember(p => p.Football, d => d.MapFrom(z => z.FootballProfile));
    }
}
#endif