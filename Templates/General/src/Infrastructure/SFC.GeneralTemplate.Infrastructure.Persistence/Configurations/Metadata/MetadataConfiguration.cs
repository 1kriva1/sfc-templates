using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Domain.Entities.Metadata;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataConfiguration : IEntityTypeConfiguration<MetadataEntity>
{
    public void Configure(EntityTypeBuilder<MetadataEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasKey(e => new { e.Service, e.Type });

        builder.HasOne<MetadataService>()
               .WithMany()
               .HasForeignKey(t => t.Service)
               .IsRequired(true);

        builder.HasOne<MetadataType>()
              .WithMany()
              .HasForeignKey(t => t.Type)
              .IsRequired(true);

        builder.HasOne<MetadataState>()
               .WithMany()
               .HasForeignKey(t => t.State)
               .IsRequired(true);

        builder.ToTable("Metadata", DatabaseConstants.MetadataSchemaName);
    }
}