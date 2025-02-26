using Microsoft.EntityFrameworkCore;

using SFC.GeneralTemplate.Domain.Entities.Metadata;
using SFC.GeneralTemplate.Infrastructure.Persistence.Extensions;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Seeds;
public static class MetadataSeed
{
    public static void SeedMetadata(this ModelBuilder builder, bool isDevelopment)
    {
        builder.SeedEnumValues<MetadataService, MetadataServiceEnum>(@enum => new MetadataService(@enum));

        builder.SeedEnumValues<MetadataType, MetadataTypeEnum>(@enum => new MetadataType(@enum));

        builder.SeedEnumValues<MetadataState, MetadataStateEnum>(@enum => new MetadataState(@enum));

        List<MetadataEntity> metadata = [
            new MetadataEntity { Service = MetadataServiceEnum.Data, Type = MetadataTypeEnum.Initialization, State = MetadataStateEnum.Required },
            new MetadataEntity { Service = MetadataServiceEnum.Identity, Type = MetadataTypeEnum.Seed, State = isDevelopment ? MetadataStateEnum.Required : MetadataStateEnum.NotRequired }
        ];

        builder.Entity<MetadataEntity>().HasData(metadata);
    }
}
