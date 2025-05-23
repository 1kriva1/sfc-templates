#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Application.Common.Dto.Common;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Domain.Entities.Team.Player;

namespace SFC.GeneralTemplate.Application.Common.Dto.Team.Player;
public class TeamPlayerDto : AuditableDto, IMapFromReverse<TeamPlayer>
{
    public long Id { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public Guid UserId { get; set; }
}
#endif