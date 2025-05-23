using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Domain.Entities.Identity.General;
using SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Base;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.GeneralTemplate.General;
public class GeneralTemplateConfiguration : AuditableEntityConfiguration<GeneralTemplateEntity, long>
{
    public override void Configure(EntityTypeBuilder<GeneralTemplateEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<User>()
               .WithMany()
               .IsRequired(true);

        builder.ToTable("GeneralTemplateMultiple");

        base.Configure(builder);
    }
}
