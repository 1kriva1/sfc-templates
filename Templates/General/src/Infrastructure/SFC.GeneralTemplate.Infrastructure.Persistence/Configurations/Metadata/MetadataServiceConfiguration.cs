using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Domain.Entities.Metadata;
using SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Base;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataServiceConfiguration : EnumEntityConfiguration<MetadataService, MetadataServiceEnum>
{
    public override void Configure(EntityTypeBuilder<MetadataService> builder)
    {
        builder.ToTable("Services", DatabaseConstants.MetadataSchemaName);
        base.Configure(builder);
    }
}
