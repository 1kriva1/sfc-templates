#if IncludePlayerInfrastructure
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Domain.Entities.Data;
using SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Base;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Data;
public class WorkingFootConfiguration : EnumDataEntityConfiguration<WorkingFoot, WorkingFootEnum>
{
    public override void Configure(EntityTypeBuilder<WorkingFoot> builder)
    {
        builder.ToTable("WorkingFoots", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}
#endif