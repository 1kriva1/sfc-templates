namespace SFC.GeneralTemplate.Application.Common.Enums;
public enum RequestId
{
    // main
    DatabaseReset,
    // core
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
    CreatePlayers
#endif
}
