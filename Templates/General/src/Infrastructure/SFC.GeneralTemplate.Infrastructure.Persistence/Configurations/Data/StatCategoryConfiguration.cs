#if IncludePlayerInfrastructure
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Domain.Entities.Data;
using SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Base;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Data;
public class StatCategoryConfiguration : EnumDataEntityConfiguration<StatCategory, StatCategoryEnum>
{
    public override void Configure(EntityTypeBuilder<StatCategory> builder)
    {
        builder.HasMany(e => e.Types)
               .WithOne()
               .HasForeignKey(t => t.CategoryId)
               .IsRequired(true);

        builder.ToTable("StatCategories", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}
#endif