#if IncludeTeamInfrastructure
using SFC.GeneralTemplate.Domain.Entities.Team.General;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Entities.Team.Data;
using SFC.GeneralTemplate.Domain.Entities.Team.Player;
#endif

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
public interface ITeamDbContext : IDbContext
{
    #region General

    IQueryable<TeamEntity> Teams { get; }

    IQueryable<TeamGeneralProfile> GeneralProfiles { get; }

    IQueryable<TeamFinancialProfile> FinancialProfiles { get; }

    IQueryable<TeamAvailability> Availability { get; }

    IQueryable<TeamTag> Tags { get; }

    IQueryable<TeamShirt> Shirts { get; }

    IQueryable<TeamLogo> Logos { get; }

#if IncludePlayerInfrastructure
    IQueryable<TeamPlayer> TeamPlayers { get; }
#endif

    #endregion General

    #region Data

#if IncludePlayerInfrastructure
    IQueryable<TeamPlayerStatus> TeamPlayerStatuses { get; }
#endif

    #endregion Data
}
#endif