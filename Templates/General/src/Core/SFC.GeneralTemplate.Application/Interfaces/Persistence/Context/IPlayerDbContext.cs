#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Domain.Entities.Player;

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
public interface IPlayerDbContext : IDbContext
{
    IQueryable<PlayerEntity> Players { get; }

    IQueryable<PlayerGeneralProfile> GeneralProfiles { get; }

    IQueryable<PlayerFootballProfile> FootballProfiles { get; }

    IQueryable<PlayerAvailability> Availability { get; }

    IQueryable<PlayerAvailableDay> AvailableDays { get; }

    IQueryable<PlayerStatPoints> Points { get; }

    IQueryable<PlayerStat> Stats { get; }

    IQueryable<PlayerTag> Tags { get; }

    IQueryable<PlayerPhoto> Photos { get; }
}
#endif