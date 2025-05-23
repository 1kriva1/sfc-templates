﻿using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Application.Features.Common.Models.Find;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Paging;
using SFC.GeneralTemplate.Application.Interfaces.Cache;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Common;
public class CacheRepository<TEntity, TContext, TId>(Repository<TEntity, TContext, TId> repository, ICache cache)
    : IRepository<TEntity, TContext, TId>
    where TEntity : class
    where TContext : DbContext, IDbContext
{
    private readonly Repository<TEntity, TContext, TId> _repository = repository;

    protected ICache Cache { get; } = cache;

    protected virtual string CacheKey { get => $"{typeof(TEntity).Name}"; }

    public virtual async Task<IReadOnlyList<TEntity>> ListAllAsync()
    {
        if (!Cache.TryGet(CacheKey, out IReadOnlyList<TEntity> list))
        {
            list = await _repository.ListAllAsync()
                                    .ConfigureAwait(false);

            await Cache.SetAsync(CacheKey, list)
                        .ConfigureAwait(false);
        }

        return list;
    }

    public Task<TEntity?> GetByIdAsync(TId id) => _repository.GetByIdAsync(id);

    public Task<TEntity> AddAsync(TEntity entity) => _repository.AddAsync(entity);

    public Task DeleteAsync(TEntity entity) => _repository.DeleteAsync(entity);

    public Task UpdateAsync(TEntity entity) => _repository.UpdateAsync(entity);

    public Task<PagedList<TEntity>> FindAsync(FindParameters<TEntity> parameters) => _repository.FindAsync(parameters);

    public Task<TEntity[]> AddRangeAsync(params TEntity[] entities) => _repository.AddRangeAsync(entities);
}
