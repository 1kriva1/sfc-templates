using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Domain.Common.Interfaces;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Base;

public class AuditableReferenceEntityConfiguration<TEntity, TID> : BaseReferenceEntityConfiguration<TEntity, TID>
    where TEntity : BaseEntity<TID>, IAuditableReferenceEntity
    where TID : struct
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.CreatedDate)
            .IsRequired(true);

        builder.Property(e => e.CreatedBy)
            .IsRequired(true);

        builder.Property(e => e.LastModifiedDate)
            .IsRequired(true);

        builder.Property(e => e.LastModifiedBy)
            .IsRequired(true);

        base.Configure(builder);
    }
}