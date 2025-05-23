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

        builder.SeedEnumValues<MetadataDomain, MetadataDomainEnum>(@enum => new MetadataDomain(@enum));

        MetadataStateEnum seedState = isDevelopment ? MetadataStateEnum.Required : MetadataStateEnum.NotRequired;

        List<MetadataEntity> metadata = [
            new MetadataEntity { Service = MetadataServiceEnum.Data, Domain = MetadataDomainEnum.Data, Type = MetadataTypeEnum.Initialization, State = MetadataStateEnum.Required },
            new MetadataEntity { Service = MetadataServiceEnum.Identity, Domain = MetadataDomainEnum.User, Type = MetadataTypeEnum.Seed, State = seedState },
#if IncludePlayerInfrastructure
            new MetadataEntity { Service = MetadataServiceEnum.Player, Domain = MetadataDomainEnum.Player, Type = MetadataTypeEnum.Seed, State = seedState },
#endif
#if IncludeTeamInfrastructure            
            new MetadataEntity { Service = MetadataServiceEnum.Team, Domain = MetadataDomainEnum.Team, Type = MetadataTypeEnum.Seed, State = seedState },
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
            new MetadataEntity { Service = MetadataServiceEnum.Team, Domain = MetadataDomainEnum.Data, Type = MetadataTypeEnum.Initialization, State = MetadataStateEnum.Required },
            new MetadataEntity { Service = MetadataServiceEnum.Team, Domain = MetadataDomainEnum.TeamPlayer, Type = MetadataTypeEnum.Seed, State = seedState },
#endif
            new MetadataEntity { Service = MetadataServiceEnum.GeneralTemplate, Domain = MetadataDomainEnum.GeneralTemplate, Type = MetadataTypeEnum.Seed, State = seedState }
        ];

        builder.Entity<MetadataEntity>().HasData(metadata);
    }
}
