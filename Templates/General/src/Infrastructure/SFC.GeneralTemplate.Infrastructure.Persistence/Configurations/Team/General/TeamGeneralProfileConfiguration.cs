#if IncludeTeamInfrastructure
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Application.Common.Constants;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;
using SFC.GeneralTemplate.Domain.Entities.Team.General;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Team.General;
public class TeamGeneralProfileConfiguration : IEntityTypeConfiguration<TeamGeneralProfile>
{
    public void Configure(EntityTypeBuilder<TeamGeneralProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.Name)
            .HasMaxLength(ValidationConstants.NameValueMaxLength)
            .IsRequired(true);

        builder.Property(e => e.Description)
            .HasMaxLength(ValidationConstants.DescriptionValueMaxLength)
            .IsRequired(false);

        builder.Property(e => e.City)
            .HasMaxLength(ValidationConstants.CityValueMaxLength)
            .IsRequired(true);

        builder.ToTable("GeneralProfiles", DatabaseConstants.TeamSchemaName);
    }
}
#endif