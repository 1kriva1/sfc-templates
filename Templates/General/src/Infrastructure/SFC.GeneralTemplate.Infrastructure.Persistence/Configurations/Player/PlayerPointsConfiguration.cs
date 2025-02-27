#if IncludePlayerInfrastructure
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Domain.Entities.Player;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Player;
public class PlayerPointsConfiguration : IEntityTypeConfiguration<PlayerStatPoints>
{
    public void Configure(EntityTypeBuilder<PlayerStatPoints> builder)
    {
        builder.Property(e => e.Available)
            .HasDefaultValue(0);

        builder.Property(e => e.Used)
            .HasDefaultValue(0);

        builder.ToTable("Points", DatabaseConstants.PlayerSchemaName);
    }
}
#endif