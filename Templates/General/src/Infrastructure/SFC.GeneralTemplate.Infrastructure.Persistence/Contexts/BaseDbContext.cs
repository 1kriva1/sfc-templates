using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Infrastructure.Persistence.Interceptors;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
public abstract class BaseDbContext<TContext>(
    DbContextOptions<TContext> options,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor) : DbContext(options) 
    where TContext : DbContext
{
    private readonly DispatchDomainEventsSaveChangesInterceptor _eventsInterceptor = eventsInterceptor;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ArgumentNullException.ThrowIfNull(optionsBuilder);
        optionsBuilder.AddInterceptors(_eventsInterceptor);
    }
}
