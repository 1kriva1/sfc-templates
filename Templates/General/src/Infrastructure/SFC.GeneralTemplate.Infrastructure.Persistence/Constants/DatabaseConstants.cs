namespace SFC.GeneralTemplate.Infrastructure.Persistence.Constants;
public static class DatabaseConstants
{
    public const string DefaultSchemaName = "GeneralTemplate";

    public const string DataSchemaName = "Data";

    public const string IdentitySchemaName = "Identity";

#if IncludePlayerInfrastructure
    public const string PlayerSchemaName = "Player";
#endif

    public const string MetadataSchemaName = "Metadata";

    public const string UserForeignKey = "UserId";

#if IncludePlayerInfrastructure
    public const string PlayerForeignKey = "PlayerId";

    public const string PlayerAvailabilityForeignKey = "AvailabilityId";
#endif
}
