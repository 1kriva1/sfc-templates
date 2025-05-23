namespace SFC.GeneralTemplate.Domain.Enums.Metadata;
public enum MetadataDomain
{
    Data,
    User,
    GeneralTemplate,
#if IncludePlayerInfrastructure
    Player,
#endif
#if IncludeTeamInfrastructure
    Team,
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
    TeamPlayer
#endif
}
