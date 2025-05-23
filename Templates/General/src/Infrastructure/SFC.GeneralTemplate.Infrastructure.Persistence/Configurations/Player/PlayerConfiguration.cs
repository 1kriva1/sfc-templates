﻿#if IncludePlayerInfrastructure
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Base;
using SFC.GeneralTemplate.Domain.Entities.Player.General;
using SFC.GeneralTemplate.Infrastructure.Persistence.Constants;
using SFC.GeneralTemplate.Domain.Entities.Identity;

namespace SFC.GeneralTemplate.Infrastructure.Persistence.Configurations.Player;
public class PlayerConfiguration : AuditableReferenceEntityConfiguration<PlayerEntity, long>
{
    public override void Configure(EntityTypeBuilder<PlayerEntity> builder)
    {
        builder.HasOne(e => e.GeneralProfile)
               .WithOne(e => e.Player)
               .HasForeignKey<PlayerGeneralProfile>()
               .IsRequired();

        builder.HasOne(e => e.FootballProfile)
               .WithOne(e => e.Player)
               .HasForeignKey<PlayerFootballProfile>()
               .IsRequired();

        builder.HasOne(e => e.Availability)
               .WithOne(e => e.Player)
               .HasForeignKey<PlayerAvailability>()
               .IsRequired();

        builder.HasOne(e => e.Photo)
               .WithOne(e => e.Player)
               .HasForeignKey<PlayerPhoto>()
               .IsRequired();

        builder.HasMany(e => e.Tags)
               .WithOne(e => e.Player)
               .HasForeignKey(DatabaseConstants.PlayerForeignKey);

        builder.HasOne(e => e.Points)
               .WithOne(e => e.Player)
               .HasForeignKey<PlayerStatPoints>()
               .IsRequired();

        builder.HasMany(e => e.Stats)
               .WithOne(e => e.Player)
               .HasForeignKey(DatabaseConstants.PlayerForeignKey);

        builder.HasOne<User>()
               .WithOne()
               .HasForeignKey<PlayerEntity>()
               .IsRequired(true);

        builder.ToTable("Players", DatabaseConstants.PlayerSchemaName);

        base.Configure(builder);
    }
}
#endif