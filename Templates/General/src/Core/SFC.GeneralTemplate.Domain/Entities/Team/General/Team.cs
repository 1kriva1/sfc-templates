#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Domain.Common.Interfaces;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Entities.Team.Player;
#endif

namespace SFC.GeneralTemplate.Domain.Entities.Team.General;
public class Team : BaseAuditableReferenceEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public required TeamGeneralProfile GeneralProfile { get; set; }

    public required TeamFinancialProfile FinancialProfile { get; set; }

    public TeamLogo? Logo { get; set; }

    public ICollection<TeamAvailability> Availability { get; } = [];

    public ICollection<TeamTag> Tags { get; } = [];

    public ICollection<TeamShirt> Shirts { get; } = [];

#if IncludePlayerInfrastructure
    public ICollection<TeamPlayer> Players { get; } = [];
#endif
}
#endif