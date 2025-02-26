using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Domain.Entities.Metadata;
using SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Base;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataStateConfiguration : EnumEntityConfiguration<MetadataState, MetadataStateEnum>
{
    public override void Configure(EntityTypeBuilder<MetadataState> builder)
    {
        builder.ToTable("States", DatabaseConstants.MetadataSchemaName);
        base.Configure(builder);
    }
}
