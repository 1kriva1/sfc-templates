using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Metadata;
using SFC.GeneralTemplate.Infrastructure.Persistence.Contexts;
using SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Common;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Repositories.Metadata;
public class MetadataRepository(MetadataDbContext context)
    : Repository<MetadataEntity, MetadataDbContext, int>(context), IMetadataRepository
{
    public Task<MetadataEntity?> GetByIdAsync(MetadataServiceEnum service, MetadataDomainEnum domain, MetadataTypeEnum type)
    {
        return Context.Metadata.FirstOrDefaultAsync(metadata =>
            metadata.Service == service &&
            metadata.Domain == domain &&
            metadata.Type == type);
    }
}