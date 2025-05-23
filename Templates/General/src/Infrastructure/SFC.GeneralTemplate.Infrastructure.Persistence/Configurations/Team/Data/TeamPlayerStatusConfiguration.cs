#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Base;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;
using SFC.GeneralTemplate.Domain.Entities.Team.Data;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Team.Data;
public class TeamPlayerStatusConfiguration : EnumDataEntityConfiguration<TeamPlayerStatus, TeamPlayerStatusEnum>
{
    public override void Configure(EntityTypeBuilder<TeamPlayerStatus> builder)
    {
        builder.ToTable("PlayerStatuses", DatabaseConstants.TeamSchemaName);
        base.Configure(builder);
    }
}
#endif