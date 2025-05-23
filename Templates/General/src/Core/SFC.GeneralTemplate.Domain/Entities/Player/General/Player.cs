#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Domain.Common.Interfaces;
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using SFC.GeneralTemplate.Domain.Entities.Team.Player;
#endif

namespace SFC.GeneralTemplate.Domain.Entities.Player.General;
public class Player : BaseAuditableReferenceEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public PlayerGeneralProfile GeneralProfile { get; set; } = null!;

    public PlayerFootballProfile FootballProfile { get; set; } = null!;

    public PlayerAvailability Availability { get; set; } = null!;

    public PlayerStatPoints Points { get; set; } = null!;

    public PlayerPhoto Photo { get; set; } = null!;

    public ICollection<PlayerTag> Tags { get; } = [];

    public ICollection<PlayerStat> Stats { get; } = [];

#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
    public ICollection<TeamPlayer> Teams { get; } = [];
#endif
}
#endif