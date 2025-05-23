#if IncludePlayerInfrastructure
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SFC.GeneralTemplate.Application.Interfaces.Reference;
using SFC.GeneralTemplate.Domain.Common.Interfaces;
using SFC.GeneralTemplate.Application.Common.Exceptions;
using SFC.GeneralTemplate.Application.Common.Constants;
using SFC.GeneralTemplate.Infrastructure.Persistence.Extensions;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Interceptors;
public class PlayerEntitySaveChangesInterceptor(IPlayerReference playerReference) : SaveChangesInterceptor
{
    private readonly IPlayerReference _playerReference = playerReference;

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context, cancellationToken);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context, CancellationToken cancellationToken = default)
    {
        if (context == null) return;

        IEnumerable<EntityEntry<IPlayerEntity>> entries = context.ChangeTracker.Entries<IPlayerEntity>();

        foreach (EntityEntry<IPlayerEntity> entry in entries)
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                if (entry.Entity.Player is null)
                {
                    Task<PlayerEntity> player = GetPlayerAsync(entry.Entity.PlayerId, cancellationToken);
                    entry.SetReference(context, player.Result);
                }
            }
        }
    }

    private async Task<PlayerEntity> GetPlayerAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _playerReference.GetAsync(id, cancellationToken).ConfigureAwait(true)
                    ?? throw new NotFoundException(Localization.PlayerNotFound);
    }
}
#endif