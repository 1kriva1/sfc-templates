namespace SFC.GeneralTemplate.Application.Common.Enums;
public enum RequestId
{
    // main
    DatabaseReset,
    // core
#if IncludeDataInfrastructure
    GetAllGeneralTemplateData,
#endif
    CreateGeneralTemplate,
    UpdateGeneralTemplate,
    GetGeneralTemplate,
    GetGeneralTemplates,
    // data
    InitData,
    ResetData,
    // identity
    CreateUser,
    CreateUsers,
#if IncludePlayerInfrastructure
    // player
    CreatePlayer,
    UpdatePlayer,
    CreatePlayers,
#endif
#if IncludeTeamInfrastructure
    // team
    ResetTeamData,
    CreateTeam,
    UpdateTeam,
    CreateTeams,    
#endif
#if (IncludePlayerInfrastructure && IncludeTeamInfrastructure)
    // team player
    CreateTeamPlayer,
    UpdateTeamPlayer,
    CreateTeamPlayers
#endif
}
