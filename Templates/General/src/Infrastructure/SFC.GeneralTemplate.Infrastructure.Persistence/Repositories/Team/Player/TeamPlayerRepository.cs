﻿#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Application.Features.Common.Models.Find;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Paging;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Common;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.GeneralTemplate.Domain.Entities.Team.Player;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
using SFC.GeneralTemplate.Infrastructure.Persistence.Extensions;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Team.Player;
public class TeamPlayerRepository(TeamDbContext context)
    : Repository<TeamPlayer, TeamDbContext, long>(context), ITeamPlayerRepository
{
    public override Task<PagedList<TeamPlayer>> FindAsync(FindParameters<TeamPlayer> parameters)
    {
        return Context.TeamPlayers
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo)
                      .AsQueryable()
                      .PaginateAsync(parameters);
    }

    public Task<TeamPlayer?> GetByIdAsync(long teamId, long playerId)
    {
        return Context.TeamPlayers.FirstOrDefaultAsync(item => item.TeamId == teamId && item.Player.Id == playerId);
    }

    public Task<bool> AnyAsync(long teamId, long playerId)
    {
        return Context.TeamPlayers.AnyAsync(item => item.TeamId == teamId && item.Player.Id == playerId);
    }

    public Task<bool> AnyAsync(long teamId, long playerId, TeamPlayerStatusEnum status)
    {
        return Context.TeamPlayers.AnyAsync(teamPlayer =>
            teamPlayer.TeamId == teamId &&
            teamPlayer.StatusId == status &&
            teamPlayer.Player.Id == playerId);
    }

    public async Task<TeamPlayer[]> AddRangeIfNotExistsAsync(params TeamPlayer[] entities)
    {
        await Context.Set<TeamPlayer>().AddRangeIfNotExistsAsync<TeamPlayer, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }
}
#endif