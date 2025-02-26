#if IncludePlayerInfrastructure
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Domain.Entities.Player;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Player;
public class PlayerAvailableDayConfiguration : IEntityTypeConfiguration<PlayerAvailableDay>
{
    public void Configure(EntityTypeBuilder<PlayerAvailableDay> builder)
    {
        builder.Property(e => e.Day)
            .HasConversion<byte>()
            .IsRequired(true);

        builder.ToTable("AvailableDays", DatabaseConstants.PlayerSchemaName);
    }
}
#endif