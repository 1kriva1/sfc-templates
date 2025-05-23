namespace SFC.GeneralTemplate.Domain.Enums.Metadata;
public enum MetadataService
{
    Data,
    Identity,
#if IncludePlayerInfrastructure
    Player,
#endif
#if IncludeTeamInfrastructure
    Team,
#endif
    GeneralTemplate
}
