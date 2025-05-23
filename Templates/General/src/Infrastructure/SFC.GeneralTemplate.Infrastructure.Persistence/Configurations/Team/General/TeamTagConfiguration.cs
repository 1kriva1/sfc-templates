#if IncludeTeamInfrastructure
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SFC.GeneralTemplate.Domain.Entities.Team.General;
using SFC.GeneralTemplate.Application.Common.Constants;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Team.General;
public class TeamTagConfiguration : IEntityTypeConfiguration<TeamTag>
{
    public void Configure(EntityTypeBuilder<TeamTag> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.Value)
            .HasMaxLength(ValidationConstants.TagValueMaxLength)
            .IsRequired(true);

        builder.ToTable("Tags", DatabaseConstants.TeamSchemaName);
    }
}
#endif