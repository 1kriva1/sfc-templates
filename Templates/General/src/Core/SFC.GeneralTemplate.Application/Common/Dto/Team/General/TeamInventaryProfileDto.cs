#if IncludeTeamInfrastructure
using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;

namespace SFC.GeneralTemplate.Application.Common.Dto.Team.General;
public class TeamInventaryProfileDto : IMapFrom<TeamEntity>
{
    public IEnumerable<int> Shirts { get; set; } = [];

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamEntity, TeamInventaryProfileDto>()
                    .ForMember(p => p.Shirts, d => d.MapFrom(z => z.Shirts));
    }
}
#endif