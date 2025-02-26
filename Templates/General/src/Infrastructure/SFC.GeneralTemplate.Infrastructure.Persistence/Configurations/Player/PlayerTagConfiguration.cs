﻿#if IncludePlayerInfrastructure
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.GeneralTemplate.Application.Common.Constants;
using SFC.GeneralTemplate.Domain.Entities.Player;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Player;
public class PlayerTagConfiguration : IEntityTypeConfiguration<PlayerTag>
{
    public void Configure(EntityTypeBuilder<PlayerTag> builder)
    {
        builder.Property(e => e.Value)
            .HasMaxLength(ValidationConstants.TagValueMaxLength)
            .IsRequired(true);

        builder.ToTable("Tags", DatabaseConstants.PlayerSchemaName);
    }
}
#endif