#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Domain.Entities.Team.General;

namespace SFC.GeneralTemplate.Application.Common.Dto.Team.General;
public class TeamAvailabilityDto : IMapFromReverse<TeamAvailability>
{
    public DayOfWeek Day { get; set; }

    public TimeSpan From { get; set; }

    public TimeSpan To { get; set; }
}
#endif