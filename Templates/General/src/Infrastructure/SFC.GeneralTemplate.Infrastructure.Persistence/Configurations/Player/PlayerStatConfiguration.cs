#if IncludePlayerInfrastructure
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Domain.Entities.Data;
using SFC.GeneralTemplate.Domain.Entities.Player.General;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Player;
public class PlayerStatConfiguration : IEntityTypeConfiguration<PlayerStat>
{
    public void Configure(EntityTypeBuilder<PlayerStat> builder)
    {
        builder.HasOne<StatType>(e => e.Type)
               .WithMany()
               .HasForeignKey(t => t.TypeId)
               .IsRequired(true);

        builder.ToTable("Stats", DatabaseConstants.PlayerSchemaName);
    }
}
#endif