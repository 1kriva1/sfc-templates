#if IncludeTeamInfrastructure
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SFC.GeneralTemplate.Domain.Entities.Data;
using SFC.GeneralTemplate.Domain.Entities.Team.General;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Team.General;
public class TeamShirtConfiguration : IEntityTypeConfiguration<TeamShirt>
{
    public void Configure(EntityTypeBuilder<TeamShirt> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<Shirt>()
               .WithMany()
               .HasForeignKey(t => t.ShirtId)
               .IsRequired(true);

        builder.ToTable("Shirts", DatabaseConstants.TeamSchemaName);
    }
}
#endif