﻿#if IncludeTeamInfrastructure
using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Common;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
using SFC.GeneralTemplate.Infrastructure.Persistence.Extensions;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Team.General;
public class TeamRepository(TeamDbContext context)
    : Repository<TeamEntity, TeamDbContext, long>(context), ITeamRepository
{
    public override Task<TeamEntity?> GetByIdAsync(long id)
    {
        return Context.Teams
                    .Include(p => p.GeneralProfile)
                    .Include(p => p.FinancialProfile)
                    .Include(p => p.Shirts)
                    .Include(p => p.Availability)
                    .Include(p => p.Tags)
                    .Include(p => p.Logo)
                    .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<TeamEntity[]> AddRangeIfNotExistsAsync(params TeamEntity[] entities)
    {
        await Context.Set<TeamEntity>().AddRangeIfNotExistsAsync<TeamEntity, long>(entities).ConfigureAwait(false);

        await Context.SaveChangesAsync().ConfigureAwait(false);

        return entities;
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.Teams.AnyAsync(p => p.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.Teams.AnyAsync(p => p.Id == id && p.UserId == userId);
    }
}
#endif